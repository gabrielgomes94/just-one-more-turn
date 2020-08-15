using System.Collections.Generic;
using UnityEngine;

namespace Hex.Mesh
{
    public class RenderQuad: ITriangulatable
    {
        int vertexIndex;

        Vector3[] quadVertices = new Vector3[4];
        Color[] quadColors = new Color[2];

        public RenderQuad(
            int vertexIndex,
            Vector3[] quadVertices,
            Color[] quadColors
        ) {
            this.vertexIndex = vertexIndex;
            this.quadVertices = quadVertices;
            this.quadColors = quadColors;
        }

        public List<Vector3> AddVertices (List<Vector3> vertices)
        {
            for (int i = 0; i < 4; i++ )
            {
                vertices.Add(quadVertices[i]);
            }

            return vertices;
        }

        public List<int> AddTriangles(List<int> triangles)
        {
            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 1);

            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 3);

            return triangles;
        }


        public List<Color> AddColors (List<Color> colors) {
            for (int i = 0; i < 2; i++ )
            {
                colors.Add(quadColors[i]);
                colors.Add(quadColors[i]);
            }

            return colors;
        }
    }
}
