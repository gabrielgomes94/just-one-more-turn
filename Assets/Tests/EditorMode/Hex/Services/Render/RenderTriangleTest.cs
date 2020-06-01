using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Collections;
using Hex;

namespace Tests
{
    public class RenderTriangleTest
    {
        [Test]
        public void Test_Should_Add_Vertices_To_NativeList()
        {
            // Set
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);

            Color color1 = Color.black;
            Color color2 = Color.black;
            Color color3 = Color.black;

            NativeArray<Vector3> triangleVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3 },
                Allocator.Temp
            );

            NativeArray<Color> triangleColors = new NativeArray<Color>(
                new Color[] { color1, color2, color3 },
                Allocator.Temp
            );

            int vertexIndex = 3;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            NativeList<Vector3> verticesResult = renderTriangle.AddVertices(vertices);

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

            // Unset
            vertices.Dispose();
            triangleVertices.Dispose();
            triangleColors.Dispose();
        }

        [Test]
        public void Test_Should_Add_Triangles_To_NativeList()
        {
            // Set
            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);

            Color color1 = Color.black;
            Color color2 = Color.black;
            Color color3 = Color.black;

            NativeArray<Vector3> triangleVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3 },
                Allocator.Temp
            );

            NativeArray<Color> triangleColors = new NativeArray<Color>(
                new Color[] { color1, color2, color3 },
                Allocator.Temp
            );

            int vertexIndex = 1;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            NativeList<int> trianglesResult = renderTriangle.AddTriangles(triangles);

            // Assert
            Assert.AreEqual(1, trianglesResult[0]);
            Assert.AreEqual(2, trianglesResult[1]);
            Assert.AreEqual(3, trianglesResult[2]);

            // Unset
            triangles.Dispose();
            triangleVertices.Dispose();
            triangleColors.Dispose();
        }

        [Test]
        public void Test_Should_Add_Colors_To_NativeList()
        {
            // Set
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);

            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);

            Color color1 = Color.black;
            Color color2 = Color.black;
            Color color3 = Color.black;

            NativeArray<Vector3> triangleVertices = new NativeArray<Vector3>(
                new Vector3[] { vertex1, vertex2, vertex3 },
                Allocator.Temp
            );

            NativeArray<Color> triangleColors = new NativeArray<Color>(
                new Color[] { color1, color2, color3 },
                Allocator.Temp
            );

            int vertexIndex = 1;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            NativeList<Color> colorsResult = renderTriangle.AddColors(colors);

            // Assert
            Assert.AreEqual(Color.black, colorsResult[0]);
            Assert.AreEqual(Color.black, colorsResult[1]);
            Assert.AreEqual(Color.black, colorsResult[2]);

            // Unset
            colors.Dispose();
            triangleVertices.Dispose();
            triangleColors.Dispose();
        }
    }
}
