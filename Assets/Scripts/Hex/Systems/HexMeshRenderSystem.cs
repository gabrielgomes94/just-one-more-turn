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

        protected override void OnUpdate()
        {
            if (!shouldRender) return;

            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);

            Entities.
                WithoutBurst().
                ForEach((in Translation translation, in ColorComponent colorComponent) => {
                    float3 centerPositionFloat3 = translation.Value;
                    Vector3 centerPosition = new Vector3(
                        centerPositionFloat3.x,
                        centerPositionFloat3.y,
                        centerPositionFloat3.z
                    );

                    for (int i = 0; i < 6; i++) {
                        int vertexIndex = vertices.Length;

                        vertices = TriangulateHexMeshService.AddVertices(vertices, centerPosition, i);

                        triangles = TriangulateHexMeshService.AddTriangles(triangles, vertexIndex);

                        Color color = colorComponent.Value;
                        colors = TriangulateHexMeshService.AddColors(colors, color);
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