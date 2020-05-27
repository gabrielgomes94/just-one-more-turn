using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using Unity.Entities;
using Unity.Rendering;
using Unity.Jobs;
using System.Collections.Generic;

namespace Hex
{
    public class HexMeshRenderSystem : SystemBase
    {
        private bool shouldRender = true;
        EntityQuery query;
        public EntityManager entityManager;

        protected override void OnCreate()
        {
            query = GetEntityQuery(ComponentType.ReadOnly<ColorComponent>(), ComponentType.ReadOnly<HexCoordinates>());
        }

        protected override void OnUpdate()
        {
            if (!shouldRender) return;

            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);


            NativeArray<ColorComponent> colorsComponentsArray = query.ToComponentDataArray<ColorComponent>(Allocator.Temp);
            NativeArray<HexCoordinates> hexCoordinatesArray = query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);

            Entities.
                WithoutBurst().
                ForEach((in Translation translation, in ColorComponent colorComponent, in HexCoordinates hexCoordinates) => {
                    float3 centerPositionFloat3 = translation.Value;
                    Vector3 centerPosition = new Vector3(
                        centerPositionFloat3.x,
                        centerPositionFloat3.y,
                        centerPositionFloat3.z
                    );

                    for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++) {
                        int vertexIndex = vertices.Length;

                        vertices = TriangulateHexMeshService.AddVertices(vertices, centerPosition, direction);

                        triangles = TriangulateHexMeshService.AddTriangles(triangles, vertexIndex);

                        Color color = colorComponent.Value;

                        NeighborService neighborService = new NeighborService(
                            hexCoordinates,
                            colorComponent,
                            colorsComponentsArray,
                            hexCoordinatesArray
                        );

                        Color neighborColor = neighborService.GetNeighborColor(direction);
                        Color edgeColor = (color + neighborColor) * 0.5f;

                        Color prevNeighborColor = neighborService.GetNeighborColor(direction.Previous());
                        Color nextNeighborColor = neighborService.GetNeighborColor(direction.Next());

                        colors = TriangulateHexMeshService.AddColors(
                            colors,
                            color,
                            (color + prevNeighborColor + neighborColor) / 3f,
                            (color + neighborColor + nextNeighborColor) / 3f
                        );
                    }
                }
            ).Run();

            Mesh hexMesh = CreateHexMesh(vertices, triangles, colors);

            Entities.
                WithStructuralChanges().
                WithoutBurst().
                ForEach((Entity entity, in HexMeshTag hexMeshTag) => {
                    var render = EntityManager.GetSharedComponentData<RenderMesh>(entity);

                    EntityManager.SetSharedComponentData(
                        entity,
                        new RenderMesh() {
                            mesh = hexMesh,
                            material = render.material
                        }
                    );
                }
            ).Run();

            triangles.Dispose();
            vertices.Dispose();
            colors.Dispose();

            shouldRender = false;
        }

        private Mesh CreateHexMesh(NativeList<Vector3> vertices, NativeList<int> triangles, NativeList<Color> colors)
        {
            Mesh hexMesh = new Mesh();

            hexMesh.name = "Hex Mesh";
            hexMesh.vertices = vertices.ToArray();
            hexMesh.colors = colors.ToArray();
            hexMesh.triangles = triangles.ToArray();
            hexMesh.RecalculateNormals();

            return hexMesh;
        }
    }
}