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
        private Vector3 vertex1;
        private Vector3 vertex2;
        private Vector3 vertex3;

        private Color color1;
        private Color color2;
        private Color color3;

        [SetUp]
        public void Setup()
        {
            vertex1 = new Vector3(0f, 0f, 0f);
            vertex2 = new Vector3(0f, 0f, 2f);
            vertex3 = new Vector3(2f, 0f, 0f);

            color1 = Color.black;
            color2 = Color.black;
            color3 = Color.black;
        }

        [Test]
        public void Test_Should_Add_Vertices_To_List()
        {
            // Set
            List<Vector3> vertices = new List<Vector3>();

            Vector3[] triangleVertices = new Vector3[] { vertex1, vertex2, vertex3 };
            Color[] triangleColors = new Color[] { color1, color2, color3 };
            int vertexIndex = 3;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            List<Vector3> verticesResult = renderTriangle.AddVertices(vertices);

            Assert.That(
                new Vector3(0f, 0f, 0f),
                Is.EqualTo(verticesResult.ToArray()[0])
            );

            Assert.That(
                new Vector3(0f, 0f, 2f),
                Is.EqualTo(verticesResult.ToArray()[1])
            );

            Assert.That(
                new Vector3(2f, 0f, 0f),
                Is.EqualTo(verticesResult.ToArray()[2])
            );
        }

        [Test]
        public void Test_Should_Add_Triangles_To_List()
        {
            // Set
            List<int> triangles = new List<int>();

            Vector3[] triangleVertices = new Vector3[] { vertex1, vertex2, vertex3 };
            Color[] triangleColors = new Color[] { color1, color2, color3 };
            int vertexIndex = 1;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            List<int> trianglesResult = renderTriangle.AddTriangles(triangles);

            // Assert
            Assert.That(1, Is.EqualTo(trianglesResult[0]));
            Assert.That(2, Is.EqualTo(trianglesResult[1]));
            Assert.That(3, Is.EqualTo(trianglesResult[2]));
        }

        [Test]
        public void Test_Should_Add_Colors_To_List()
        {
            // Set
            List<Color> colors = new List<Color>();

            Vector3[] triangleVertices = new Vector3[] { vertex1, vertex2, vertex3 };
            Color[] triangleColors = new Color[] { color1, color2, color3 };
            int vertexIndex = 1;

            RenderTriangle renderTriangle = new RenderTriangle(vertexIndex, triangleVertices, triangleColors);

            // Act
            List<Color> colorsResult = renderTriangle.AddColors(colors);

            // Assert
            Assert.That(Color.black, Is.EqualTo(colorsResult[0]));
            Assert.That(Color.black, Is.EqualTo(colorsResult[1]));
            Assert.That(Color.black, Is.EqualTo(colorsResult[2]));
        }
    }
}
