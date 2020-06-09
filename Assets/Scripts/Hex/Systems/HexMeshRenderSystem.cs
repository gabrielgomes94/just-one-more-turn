using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using Unity.Entities;
using Unity.Rendering;
using Unity.Jobs;
using Unity.Physics;
using System.Collections.Generic;

namespace Hex
{
    public class HexMeshRenderSystem : SystemBase
    {
        EntityQuery query;
        public EntityManager entityManager;

        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<ColorComponent>(),
                ComponentType.ReadOnly<HexCoordinates>(),
                ComponentType.ReadOnly<Elevation>(),
                ComponentType.ReadOnly<HexCellTag>()
            );
        }

        protected override void OnUpdate()
        {
            NativeArray<ColorComponent> colorsComponentsArray = query.ToComponentDataArray<ColorComponent>(Allocator.Temp);
            NativeArray<HexCoordinates> hexCoordinatesArray = query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);

            RenderService renderService = new RenderService();

            Entities.
                WithoutBurst().
                ForEach((Entity entity, in Translation translation, in ColorComponent colorComponent, in HexCoordinates hexCoordinates) => {
                    renderService.Execute(entity, query);
                }
            ).Run();

            Mesh hexMesh = CreateHexMesh(
                renderService.GetVerticesArray(),
                renderService.GetTrianglesArray(),
                renderService.GetColorsArray()
            );

            NativeArray<float3> vertices = renderService.ConvertVerticesToNativeArray();
            NativeArray<int3> triangles = renderService.ConvertTrianglesToNativeArray();

            BlobAssetReference<Unity.Physics.Collider> collider = Unity.Physics.MeshCollider.Create(vertices, triangles);

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

                    EntityManager.SetComponentData<PhysicsCollider>(
                        entity,
                        new PhysicsCollider { Value = collider }
                    );
                }
            ).Run();

            colorsComponentsArray.Dispose();
            hexCoordinatesArray.Dispose();
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