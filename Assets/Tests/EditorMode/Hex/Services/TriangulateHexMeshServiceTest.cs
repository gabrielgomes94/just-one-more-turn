using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Collections;
using Hex;

namespace Tests
{
    public class TriangulateHexMeshServiceTest
    {
        [Test]
        public void Test_Should_Add_Vertices_To_NativeList()
        {
            // Set
            NativeList<Vector3> vertices = new NativeList<Vector3>(Allocator.TempJob);
            Vector3 centerPosition = new Vector3(0f, 0f, 0f);

            // Act
            NativeList<Vector3> verticesResult = TriangulateHexMeshService.AddVertices(vertices, centerPosition, 0);

            // Assert
            Assert.AreEqual(
                new Vector3(0f, 0f, 0f),
                verticesResult.ToArray()[0]
            );

            Assert.AreEqual(
                new Vector3(0f, 0f, 10f),
                verticesResult.ToArray()[1]
            );

            Assert.AreEqual(
                new Vector3(10f * 0.866025404f, 0f, 5f),
                verticesResult.ToArray()[2]
            );
        }

        [Test]
        public void Test_Should_Add_Triangles_To_NativeList()
        {
            // Set
            NativeList<int> triangles = new NativeList<int>(Allocator.TempJob);
            int vertexIndex = 1;

            // Act
            NativeList<int> trianglesResult = TriangulateHexMeshService.AddTriangles(triangles, vertexIndex);

            // Assert
            Assert.AreEqual(
                1,
                trianglesResult.ToArray()[0]
            );

            Assert.AreEqual(
                2,
                trianglesResult.ToArray()[1]
            );

            Assert.AreEqual(
                3,
                trianglesResult.ToArray()[2]
            );
        }

        [Test]
        public void Test_Should_Add_Colors_To_NativeList()
        {
            // Set
            NativeList<Color> colors = new NativeList<Color>(Allocator.TempJob);
            Color color = Color.blue;

            // Act
            NativeList<Color> colorsResult = TriangulateHexMeshService.AddColors(colors, color);

            // Assert
            Assert.AreEqual(
                color,
                colorsResult.ToArray()[0]
            );

            Assert.AreEqual(
                color,
                colorsResult.ToArray()[1]
            );

            Assert.AreEqual(
                color,
                colorsResult.ToArray()[2]
            );
        }
    }
}
