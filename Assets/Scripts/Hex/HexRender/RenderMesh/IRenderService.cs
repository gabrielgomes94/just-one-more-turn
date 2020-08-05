using Unity.Mathematics;

namespace Hex
{
    public interface IRenderService
    {
        float3[] GetVerticesArrayFloat3();
        int3[] GetTrianglesArrayInt3();
    }
}