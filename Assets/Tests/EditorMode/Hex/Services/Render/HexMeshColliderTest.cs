using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Collider = Unity.Physics.Collider;
using NSubstitute;
using Hex;
using Unity.Entities;
using Unity.Mathematics;

namespace Tests
{
    public class HexMeshColliderTest
    {
        [Test]
        public void Test_Create_HexMeshCollider()
        {
            // Set
            Vector3 vertex1 = new Vector3(0f, 0f, 0f);
            Vector3 vertex2 = new Vector3(0f, 0f, 2f);
            Vector3 vertex3 = new Vector3(2f, 0f, 0f);
            float3[] triangleVerticesFloat3 = new float3[] { vertex1, vertex2, vertex3 };
            int3[] trianglesArrayInt3 = new int3[] { new int3(0, 1, 2) };

            IRenderService renderService = Substitute.For<IRenderService>();

            renderService.GetVerticesArrayFloat3().Returns(triangleVerticesFloat3);
            renderService.GetTrianglesArrayInt3().Returns(trianglesArrayInt3);

            // Action
            BlobAssetReference<Collider> collider = HexMeshCollider.Create(renderService);

            // Assertion
            Assert.That(collider, Is.Not.Null);
        }
    }
}
