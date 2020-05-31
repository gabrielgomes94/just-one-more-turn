using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Hex
{
    public class RenderQuad: ITriangulatable
    {
        int vertexIndex;

        NativeArray<Color> quadColors;
        NativeArray<Vector3> quadVertices;

        public RenderQuad(
            int vertexIndex,
            NativeArray<Vector3> quadVertices,
            NativeArray<Color> quadColors
        ) {
            this.vertexIndex = vertexIndex;
            this.quadVertices = quadVertices;
            this.quadColors = quadColors;
        }

        public NativeList<Vector3> AddVertices (NativeList<Vector3> vertices)
        {
            for (int i = 0; i < 4; i++ )
            {
                vertices.Add(quadVertices[i]);
            }

            return vertices;
        }

        public NativeList<int> AddTriangles(NativeList<int> triangles)
        {
            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 1);

            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 3);

            return triangles;
        }


        public NativeList<Color> AddColors (NativeList<Color> colors) {
            for (int i = 0; i < 2; i++ )
            {
                colors.Add(quadColors[i]);
                colors.Add(quadColors[i]);
            }

            return colors;
        }
    }
}
