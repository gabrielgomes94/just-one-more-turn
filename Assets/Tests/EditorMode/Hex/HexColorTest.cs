using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hex;
using System;

namespace Tests
{
    public class HexColorTest
    {

        [Test]
        public void Get_Random_Color_From_Color_array()
        {
            // Set
            Color[] possibleColors = {
                Color.white,
                Color.green,
                Color.yellow,
                Color.gray,
                Color.blue
            };

            // Act
            Color color = HexColor.GetRandomColor();

            // Assert
            Assert.True(
                Array.Exists(
                    possibleColors,
                    possibleColor => possibleColor == color
                )
            );
        }
    }
}
