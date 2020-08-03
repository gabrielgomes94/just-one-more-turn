using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Collider = Unity.Physics.Collider;

namespace Hex
{
    public class HexMeshCollider
    {
        public static BlobAssetReference<Collider> Create(IRenderService renderService)
        {
            NativeArray<float3> vertices = new NativeArray<float3>(
                renderService.GetVerticesArrayFloat3(),
                Allocator.TempJob
            );

            NativeArray<int3> triangles = new NativeArray<int3>(
                renderService.GetTrianglesArrayInt3(),
                Allocator.TempJob
            );

            BlobAssetReference<Collider> collider = Unity.Physics.MeshCollider.Create(vertices, triangles);

            triangles.Dispose();
            vertices.Dispose();

            return collider;
        }
    }
}