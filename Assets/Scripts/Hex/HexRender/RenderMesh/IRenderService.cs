using Unity.Mathematics;

namespace Hex.Mesh
{
    public interface IRenderService
    {
        float3[] GetVerticesArrayFloat3();
        int3[] GetTrianglesArrayInt3();
    }
}