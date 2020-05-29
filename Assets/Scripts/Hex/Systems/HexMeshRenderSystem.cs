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

            NativeArray<ColorComponent> colorsComponentsArray = query.ToComponentDataArray<ColorComponent>(Allocator.Temp);
            NativeArray<HexCoordinates> hexCoordinatesArray = query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);

            RenderService renderService = new RenderService();

            Entities.
                WithoutBurst().
                ForEach((in Translation translation, in ColorComponent colorComponent, in HexCoordinates hexCoordinates) => {
                    Vector3 centerPosition = new Vector3(
                        translation.Value.x,
                        translation.Value.y,
                        translation.Value.z
                    );

                    renderService.Execute(centerPosition, hexCoordinates, colorComponent, query);
                }
            ).Run();

            Mesh hexMesh = CreateHexMesh(
                renderService.GetVerticesArray(),
                renderService.GetTrianglesArray(),
                renderService.GetColorsArray()
            );

            renderService.Dispose();

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

            colorsComponentsArray.Dispose();
            hexCoordinatesArray.Dispose();

            shouldRender = false;
        }

        private Mesh CreateHexMesh(Vector3[] vertices, int[] triangles, Color[] colors)
        {
            Mesh hexMesh = new Mesh();

            hexMesh.name = "Hex Mesh";
            hexMesh.vertices = vertices;
            hexMesh.colors = colors;
            hexMesh.triangles = triangles;
            hexMesh.RecalculateNormals();

            return hexMesh;
        }
    }
}