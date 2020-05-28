using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Hex
{
    public class RenderTriangle: ITriangulatable
    {
        int vertexIndex;
        Vector3 vertex1;
        Vector3 vertex2;
        Vector3 vertex3;
        Color color1;
        Color color2;
        Color color3;

        public RenderTriangle(
            int vertexIndex,
            Vector3 vertex1,
            Vector3 vertex2,
            Vector3 vertex3,
            Color color1,
            Color color2,
            Color color3
        ) {
            this.vertexIndex = vertexIndex;

            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.vertex3 = vertex3;

            this.color1 = color1;
            this.color2 = color2;
            this.color3 = color3;
        }

        public NativeList<Vector3> AddVertices(NativeList<Vector3> vertices)
        {
            vertices.Add(vertex1);
            vertices.Add(vertex2);
            vertices.Add(vertex3);

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
            colors.Add(color1);
            colors.Add(color2);
            colors.Add(color3);

            return colors;
        }
    }
}
