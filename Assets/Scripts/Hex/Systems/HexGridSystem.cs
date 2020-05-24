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
    public class HexGridSystem : SystemBase
    {
        private bool shouldRender = true;

        protected override void OnUpdate()
        {
            if (!shouldRender) return;

            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);

            Entities.
                ForEach((in HexCoordinatesComponent hexCoordinatesComponent, in Translation translation) => {
                    float3 centerPositionFloat3 = translation.Value;
                    Vector3 centerPosition = new Vector3(
                        centerPositionFloat3.x,
                        centerPositionFloat3.y,
                        centerPositionFloat3.z
                    );

                    for (int i = 0; i < 6; i++) {
                        int vertexIndex = vertices.Length;

                        vertices.Add(centerPosition);
                        vertices.Add(centerPosition + HexMetrics.corners[i]);
                        vertices.Add(centerPosition + HexMetrics.corners[i + 1]);

                        triangles.Add(vertexIndex);
                        triangles.Add(vertexIndex + 1);
                        triangles.Add(vertexIndex + 2);

                        Color color = Color.white;
                        colors.Add(color);
                        colors.Add(color);
                        colors.Add(color);
                    }
                }
            ).Run();

            var trianglesArray = triangles.ToArray();
            var verticesArray = vertices.ToArray();
            var colorsArray = colors.ToArray();

            Mesh hexMesh = new Mesh();
            hexMesh.name = "Hex Mesh";

            hexMesh.vertices = vertices.ToArray();
            hexMesh.colors = colors.ToArray();
            hexMesh.triangles = triangles.ToArray();

            hexMesh.RecalculateNormals();

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
    }
}