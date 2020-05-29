using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Hex
{
    public class RenderTriangle: ITriangulatable
    {
        int vertexIndex;
        NativeArray<Vector3> triangleVertices;
        NativeArray<Color> triangleColors;

        public RenderTriangle(
            int vertexIndex,
            NativeArray<Vector3> triangleVertices,
            NativeArray<Color> triangleColors

        ) {
            this.vertexIndex = vertexIndex;
            this.triangleVertices = triangleVertices;
            this.triangleColors = triangleColors;
        }

        public NativeList<Vector3> AddVertices(NativeList<Vector3> vertices)
        {
            for (int i = 0; i < 3; i++ )
            {
                vertices.Add(triangleVertices[i]);
            }

            return vertices;
        }

        public NativeList<int> AddTriangles(NativeList<int> triangles)
        {
            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);

            return triangles;
        }

        public NativeList<Color> AddColors(NativeList<Color> colors)
        {
            for (int i = 0; i < 3; i++ )
            {
                colors.Add(triangleColors[i]);
            }

            return colors;
        }
    }
}
