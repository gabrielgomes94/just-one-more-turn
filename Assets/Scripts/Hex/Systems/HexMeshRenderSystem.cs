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
        public static bool shouldRender = true;
        EntityQuery query;
        public EntityManager entityManager;

        EntityQuery shouldRenderQuery;

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
            if (!shouldRender) return;

            RenderService renderService = new RenderService(query);

            Entities.
                WithoutBurst().
                ForEach((Entity entity, in Translation translation, in ColorComponent colorComponent, in HexCoordinates hexCoordinates) => {
                    renderService.Execute(entity, colorComponent);
                }
            ).Run();

            Mesh hexMesh = CreateHexMesh(
                renderService.GetVerticesArray(),
                renderService.GetTrianglesArray(),
                renderService.GetColorsArray()
            );

            BlobAssetReference<Unity.Physics.Collider> collider = RenderColliders.CreateHexMeshCollider(renderService);

            Entities.
                WithStructuralChanges().
                WithoutBurst().
                ForEach((Entity entity, in HexMeshTag hexMeshTag) => {
                    var render = EntityManager.GetSharedComponentData<RenderMesh>(entity);

                    var renderMesh = new RenderMesh() {
                        mesh = hexMesh,
                        material = render.material
                    };

                    EntityManager.SetSharedComponentData(
                        entity,
                        renderMesh
                    );

                    EntityManager.SetComponentData<PhysicsCollider>(
                        entity,
                        new PhysicsCollider { Value = collider }
                    );
                }
            ).Run();

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