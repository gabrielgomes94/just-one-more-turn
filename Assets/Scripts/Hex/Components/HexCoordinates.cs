using Unity.Entities;
using Unity.Mathematics;

namespace Hex {
    public struct HexCoordinates : IComponentData
    {
        public int3 Value;

        public static bool operator == (HexCoordinates hexCoordinates1, HexCoordinates hexCoordinates2) {
            bool status = false;
            if (
                hexCoordinates1.Value.x == hexCoordinates2.Value.x &&
                hexCoordinates1.Value.y == hexCoordinates2.Value.y &&
                hexCoordinates1.Value.z == hexCoordinates2.Value.z
            ) {
                status = true;
            }
            return status;
        }

        public static bool operator != (HexCoordinates hexCoordinates1, HexCoordinates hexCoordinates2) {
            bool status = false;
            if (hexCoordinates1.Value.x != hexCoordinates2.Value.x) return true;
            if (hexCoordinates1.Value.y != hexCoordinates2.Value.y) return true;
            if (hexCoordinates1.Value.z != hexCoordinates2.Value.z) return true;

            return status;
        }
    }
}
