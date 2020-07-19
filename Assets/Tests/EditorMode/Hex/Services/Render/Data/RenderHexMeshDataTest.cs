using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hex;

namespace Tests
{
    public class RenderHexMeshDataTest
    {
        [Test]
        public void RenderHexMeshDataTestSimplePasses()
        {
            // Set
            RenderHexMeshData renderHexMeshData = new RenderHexMeshData();

            renderHexMeshData.triangles = new List<int>() { 0, 1, 2 };
            renderHexMeshData.vertices = new List<Vector3>() { new Vector3(0, 1, 2) };
            renderHexMeshData.colors = new List<Color>() {
                Color.black,
                Color.black
            };

            // Act
            renderHexMeshData.Clear();

            // Assert
            Assert.That(renderHexMeshData.triangles, Is.Empty);
            Assert.That(renderHexMeshData.vertices, Is.Empty);
            Assert.That(renderHexMeshData.colors, Is.Empty);
        }
    }
}
