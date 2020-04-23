using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hex;

namespace Tests
{
    public class HexMetricsTest
    {
        [Test]
        public void HexMetricsTestSimplePasses()
        {
            Vector3[] corners = HexMetrics.corners;

            Assert.AreEqual(corners[0], new Vector3(0f, 0f, 10f));

            Assert.AreEqual(
                corners[1],
                new Vector3(
                    10f *  0.866025404f,
                    0f,
                    0.5f * 10f
                )
            );

            Assert.AreEqual(
                corners[2],
                new Vector3(
                    10f *  0.866025404f,
                    0f,
                    -0.5f * 10f
                )
            );

            Assert.AreEqual(
                corners[3],
                new Vector3(
                    0f,
                    0f,
                    -10f
                )
            );

            Assert.AreEqual(
                corners[4],
                new Vector3(
                    -10f *  0.866025404f,
                    0f,
                    -0.5f * 10f
                )
            );

            Assert.AreEqual(
                corners[5],
                new Vector3(
                    -10f *  0.866025404f,
                    0f,
                    0.5f * 10f
                )
            );

            Assert.AreEqual(corners[6], new Vector3(0f, 0f, 10f));
        }
    }
}
