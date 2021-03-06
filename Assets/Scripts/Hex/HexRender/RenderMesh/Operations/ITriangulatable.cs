﻿using System.Collections.Generic;
using UnityEngine;

namespace Hex.Render
{
    interface ITriangulatable
    {
        List<int> AddTriangles(List<int> triangles);
        List<Vector3> AddVertices(List<Vector3> vertices);
        List<Color> AddColors(List<Color> colors);
    }
}
