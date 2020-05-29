using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Hex {
    public struct HexCoordinates : IComponentData
    {
        public int X, Y, Z;

        public static bool operator == (HexCoordinates hexCoordinates1, HexCoordinates hexCoordinates2) {
            bool status = false;
            if (
                hexCoordinates1.X == hexCoordinates2.X &&
                hexCoordinates1.Y == hexCoordinates2.Y &&
                hexCoordinates1.Z == hexCoordinates2.Z
            ) {
                status = true;
            }
            return status;
        }

        public static bool operator != (HexCoordinates hexCoordinates1, HexCoordinates hexCoordinates2) {
            bool status = false;
            if (hexCoordinates1.X != hexCoordinates2.X) return true;
            if (hexCoordinates1.Y != hexCoordinates2.Y) return true;
            if (hexCoordinates1.Z != hexCoordinates2.Z) return true;

            return status;
        }
    }
}
