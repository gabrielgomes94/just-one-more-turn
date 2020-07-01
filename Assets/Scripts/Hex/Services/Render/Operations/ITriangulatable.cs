using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Hex
{
    interface ITriangulatable
    {
        List<int> AddTriangles(List<int> triangles);
        List<Vector3> AddVertices(List<Vector3> vertices);
        List<Color> AddColors(List<Color> colors);
    }
}
