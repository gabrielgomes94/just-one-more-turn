using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hex;

namespace Tests
{
    public class HexCoordinatesTest
    {
        [Test]
        public void Instantiate_HexCoordinates_From_Offset_Coordinates()
        {
            HexCoordinates hexCoordinates = HexCoordinates.FromOffsetCoordinates(1, 3);

            Assert.AreEqual(hexCoordinates.X, 1 - 3 /2);
            Assert.AreEqual(hexCoordinates.Z, 3);
        }

        [Test]
        public void Test_Get_Coordinates_String_Formatted()
        {
            HexCoordinates hexCoordinates = new HexCoordinates(1, 1);
            string hexCoordinatesText = "(1, -2, 1)";

            Assert.AreEqual(hexCoordinates.ToString(), hexCoordinatesText);
        }

        [Test]
        public void Test_Get_Coordinates_String_Formatted_On_SepareteLines()
        {
            HexCoordinates hexCoordinates = new HexCoordinates(1, 1);
            string hexCoordinatesText = "1\n-2\n1";

            Assert.AreEqual(hexCoordinates.ToStringOnSeparateLines(), hexCoordinatesText);
        }
    }
}
