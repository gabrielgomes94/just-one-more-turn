using UnityEngine;

namespace Hex
{
    public interface IRenderData
    {
        Vector3 CenterPosition {get;}
        Vector3 Vertex1 {get;}
        Vector3 Vertex2 {get;}
        Vector3 Vertex3 {get;}
        Vector3 Vertex4 {get;}
    }
}