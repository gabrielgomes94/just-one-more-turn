using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Hex
{
    interface ITriangulatable
    {
        NativeList<int> AddTriangles(NativeList<int> triangles);
        NativeList<Vector3> AddVertices(NativeList<Vector3> vertices);
        NativeList<Color> AddColors(NativeList<Color> colors);
    }
}
