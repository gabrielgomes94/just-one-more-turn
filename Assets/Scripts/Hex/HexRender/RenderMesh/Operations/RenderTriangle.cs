using System.Collections.Generic;
using UnityEngine;

namespace Hex.Render
{
    public class RenderTriangle: ITriangulatable
    {
        int vertexIndex;
        Vector3[] triangleVertices = new Vector3[3];
        Color[] triangleColors = new Color[3];

        public RenderTriangle(
            int vertexIndex,
            Vector3[] triangleVertices,
            Color[] triangleColors

        ) {
            this.vertexIndex = vertexIndex;
            this.triangleVertices = triangleVertices;
            this.triangleColors = triangleColors;
        }

        public List<Vector3> AddVertices(List<Vector3> vertices)
        {
            for (int i = 0; i < 3; i++ )
            {
                vertices.Add(triangleVertices[i]);
            }

            return vertices;
        }

        public List<int> AddTriangles(List<int> triangles)
        {
            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);

            return triangles;
        }

        public List<Color> AddColors(List<Color> colors)
        {
            for (int i = 0; i < 3; i++ )
            {
                colors.Add(triangleColors[i]);
            }

            return colors;
        }
    }
}
