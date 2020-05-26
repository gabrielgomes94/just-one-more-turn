using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulateHexMeshService
{
    public static NativeList<Vector3> AddVertices(NativeList<Vector3> vertices, Vector3 centerPosition, int i)
    {
        vertices.Add(centerPosition);
        vertices.Add(centerPosition + HexMetrics.corners[i]);
        vertices.Add(centerPosition + HexMetrics.corners[i + 1]);

        return vertices;
    }

    public static NativeList<int> AddTriangles(NativeList<int> triangles, int vertexIndex)
    {
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);

        return triangles;
    }

    public static NativeList<Color> AddColors(NativeList<Color> colors, Color color)
    {
        colors.Add(color);
        colors.Add(color);
        colors.Add(color);

        return colors;
    }
}
