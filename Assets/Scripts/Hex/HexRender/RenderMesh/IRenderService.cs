using Unity.Mathematics;

namespace Hex.Render
{
    public interface IRenderService
    {
        float3[] GetVerticesArrayFloat3();
        int3[] GetTrianglesArrayInt3();
    }
}