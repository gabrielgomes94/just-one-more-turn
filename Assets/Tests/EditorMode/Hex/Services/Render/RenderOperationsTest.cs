using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Entities;
using Hex;
using NSubstitute;

namespace Tests
{
    public class RenderOperationsTest
    {
        private IRenderData renderData;
        private RenderHexMeshData renderHexMeshData;

        private RenderOperations renderOperations;

        [SetUp]
        public void Setup()
        {
            renderData = Substitute.For<IRenderData>();

            renderHexMeshData = new RenderHexMeshData();

            renderOperations = new RenderOperations(
                renderData,
                renderHexMeshData
            );
        }

        [Test]
        public void Test_Should_Create_Main_Triangle()
        {
            // Set
            renderData.CenterPosition.Returns(new Vector3(0, 0, 0));
            renderData.Vertex1.Returns(new Vector3(0, 0, 1));
            renderData.Vertex2.Returns(new Vector3(1, 0, 0));

            Color color = Color.black;

            // Act
            renderOperations.CreateMainTriangle(color);

            // Assert
            Assert.That(renderHexMeshData.vertices.Count, Is.EqualTo(3));
            Assert.That(renderHexMeshData.triangles.Count, Is.EqualTo(3));
            Assert.That(renderHexMeshData.colors.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Should_Create_Edge_Quad()
        {
            // Set
            renderData.CenterPosition.Returns(new Vector3(0, 0, 0));
            renderData.Vertex1.Returns(new Vector3(0, 0, 1));
            renderData.Vertex2.Returns(new Vector3(1, 0, 0));

            Color color1 = Color.black;
            Color color2 = Color.white;

            // Act
            renderOperations.CreateEdgeQuad(color1, color2);

            // Assert
            Assert.That(renderHexMeshData.vertices.Count, Is.EqualTo(4));
            Assert.That(renderHexMeshData.triangles.Count, Is.EqualTo(6));
            Assert.That(renderHexMeshData.colors.Count, Is.EqualTo(4));
        }

        [Test]
        public void Test_Should_Create_Corner_Triangle()
        {
            // Set
            renderData.CenterPosition.Returns(new Vector3(0, 0, 0));
            renderData.Vertex1.Returns(new Vector3(0, 0, 1));
            renderData.Vertex2.Returns(new Vector3(1, 0, 0));

            Color color1 = Color.black;
            Color color2 = Color.blue;
            Color color3 = Color.white;

            int elevation = 2;

            // Act
            renderOperations.CreateCornerTriangle(
                color1,
                color2,
                color3,
                HexDirection.E,
                elevation
            );

            // Assert
            Assert.That(renderHexMeshData.vertices.Count, Is.EqualTo(3));
            Assert.That(renderHexMeshData.triangles.Count, Is.EqualTo(3));
            Assert.That(renderHexMeshData.colors.Count, Is.EqualTo(3));
        }
    }
}
