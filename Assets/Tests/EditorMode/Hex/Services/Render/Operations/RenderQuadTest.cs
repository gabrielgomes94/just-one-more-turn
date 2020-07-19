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
        private Vector3 vertex1;
        private Vector3 vertex2;
        private Vector3 vertex3;
        private Vector3 vertex4;

        private Color color1;
        private Color color2;

        [SetUp]
        public void Setup()
        {
            vertex1 = new Vector3(0f, 0f, 0f);
            vertex2 = new Vector3(0f, 0f, 2f);
            vertex3 = new Vector3(2f, 0f, 0f);
            vertex4 = new Vector3(2f, 0f, 2f);

            color1 = Color.black;
            color2 = Color.black;
        }

        [Test]
        public void Test_Should_Add_Vertices_To_List()
        {
            // Set
            List<Vector3> vertices = new List<Vector3>();

            Vector3[] quadVertices = new Vector3[] { vertex1, vertex2, vertex3, vertex4 } ;

            Color[] quadColors = new Color[] { color1, color2 } ;

            int vertexIndex = 3;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            List<Vector3> verticesResult = renderQuad.AddVertices(vertices);

            // Assert
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

            Assert.That(
                new Vector3(2f, 0f, 2f),
                Is.EqualTo(verticesResult.ToArray()[3])
            );
        }

        [Test]
        public void Test_Should_Add_Triangles_To_List()
        {
            // Set
            List<int> triangles = new List<int>();

            Vector3[] quadVertices = new Vector3[] { vertex1, vertex2, vertex3, vertex4 } ;

            Color[] quadColors = new Color[] { color1, color2 } ;

            int vertexIndex = 1;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            List<int> trianglesResult = renderQuad.AddTriangles(triangles);

            // Assert
            Assert.That(1, Is.EqualTo(trianglesResult[0]));
            Assert.That(3, Is.EqualTo(trianglesResult[1]));
            Assert.That(2, Is.EqualTo(trianglesResult[2]));
            Assert.That(2, Is.EqualTo(trianglesResult[3]));
            Assert.That(3, Is.EqualTo(trianglesResult[4]));
            Assert.That(4, Is.EqualTo(trianglesResult[5]));
        }

        [Test]
        public void Test_Should_Add_Colors_To_List()
        {
            // Set
            List<Color> colors = new List<Color>();

            Vector3[] quadVertices = new Vector3[] { vertex1, vertex2, vertex3, vertex4 } ;

            Color[] quadColors = new Color[] { color1, color2 } ;

            int vertexIndex = 1;

            RenderQuad renderQuad = new RenderQuad(vertexIndex, quadVertices, quadColors);

            // Act
            List<Color> colorsResult = renderQuad.AddColors(colors);

            // Assert
            Assert.That(Color.black, Is.EqualTo(colorsResult[0]));
            Assert.That(Color.black, Is.EqualTo(colorsResult[1]));
            Assert.That(Color.black, Is.EqualTo(colorsResult[2]));
            Assert.That(Color.black, Is.EqualTo(colorsResult[3]));
        }
    }
}
