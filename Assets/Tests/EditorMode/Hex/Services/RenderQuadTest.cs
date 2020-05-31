using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hex;
using Unity.Collections;

namespace Tests
{
    public class RenderQuadTest
    {
        [Test]
        public void Test_Should_Add_Vertices_To_NativeList()
        {
            // Set
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);
            Vector3 vertex4 = new Vector3(2f, 0f, 2f);

            Color color1 = Color.black;
            Color color2 = Color.black;

            NativeArray<Vector3> quadVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3, vertex4,
                },
                Allocator.Temp
            );

            NativeArray<Color> quadColors = new NativeArray<Color>(
                new Color[] { color1, color2 },
                Allocator.Temp
            );

            int vertexIndex = 3;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            NativeList<Vector3> verticesResult = renderQuad.AddVertices(vertices);

            // Assert
            Assert.AreEqual(
                new Vector3(0f, 0f, 0f),
                verticesResult.ToArray()[0]
            );

            Assert.AreEqual(
                new Vector3(0f, 0f, 2f),
                verticesResult.ToArray()[1]
            );

            Assert.AreEqual(
                new Vector3(2f, 0f, 0f),
                verticesResult.ToArray()[2]
            );

            Assert.AreEqual(
                new Vector3(2f, 0f, 2f),
                verticesResult.ToArray()[3]
            );

            // Unset
            vertices.Dispose();
            quadVertices.Dispose();
            quadColors.Dispose();
        }

        [Test]
        public void Test_Should_Add_Triangles_To_NativeList()
        {
            // Set
            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);
            Vector3 vertex4 = new Vector3(2f, 0f, 2f);

            Color color1 = Color.black;
            Color color2 = Color.black;

            NativeArray<Vector3> quadVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3, vertex4,
                },
                Allocator.TempJob
            );

            NativeArray<Color> quadColors = new NativeArray<Color>(
                new Color[] { color1, color2 },
                Allocator.TempJob
            );

            int vertexIndex = 1;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            NativeList<int> trianglesResult = renderQuad.AddTriangles(triangles);

            // Assert
            Assert.AreEqual(1, trianglesResult[0]);
            Assert.AreEqual(3, trianglesResult[1]);
            Assert.AreEqual(2, trianglesResult[2]);
            Assert.AreEqual(2, trianglesResult[3]);
            Assert.AreEqual(3, trianglesResult[4]);
            Assert.AreEqual(4, trianglesResult[5]);

            // Unset
            triangles.Dispose();
            quadVertices.Dispose();
            quadColors.Dispose();
        }

        [Test]
        public void Test_Should_Add_Colors_To_NativeList()
        {
            // Set
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);
            Vector3 vertex4 = new Vector3(2f, 0f, 2f);

            Color color1 = Color.black;
            Color color2 = Color.white;

            NativeArray<Vector3> quadVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3, vertex4,
                },
                Allocator.TempJob
            );

            NativeArray<Color> quadColors = new NativeArray<Color>(
                new Color[] { color1, color2 },
                Allocator.TempJob
            );

            int vertexIndex = 1;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            NativeList<Color> colorsResult = renderQuad.AddColors(colors);

            // Assert
            Assert.AreEqual(Color.black, colorsResult[0]);
            Assert.AreEqual(Color.black, colorsResult[1]);
            Assert.AreEqual(Color.white, colorsResult[2]);
            Assert.AreEqual(Color.white, colorsResult[3]);

            // Unset
            colors.Dispose();
            quadVertices.Dispose();
            quadColors.Dispose();
        }
    }
}
