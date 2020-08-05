using UnityEngine;
using Unity.Mathematics;

namespace Hex
{
    public class CoordinatesService
    {
        public static HexCoordinates CreateFromOffset(int x, int z)
        {
            int offSetX = x - z / 2;

            return Create(offSetX, z);
        }

        public static HexCoordinates Create(int x, int z)
        {
            return new HexCoordinates {
                Value = new int3(
                    x,
                    -x -z,
                    z
                )
            };
        }

        public static HexCoordinates GetCoordinatesFromPosition(float3 position)
        {
            float x = (position.x) / (HexMetrics.innerRadius * 2f) ;
            float y = -x;
            float offset = position.z / (HexMetrics.outerRadius * 3f);

            x -= offset;
            y -= offset;

            int iX = (int) math.round(x);
            int iY = (int) math.round(y);
            int iZ = (int) math.round(-x -y);

            if (iX + iY + iZ != 0) {
			    Debug.LogWarning("rounding error!");

                float dX = math.abs(x - iX);
                float dY = math.abs(y - iY);
                float dZ = math.abs(-x -y - iZ);

                if (dX > dY && dX > dZ) {
                    iX = -iY - iZ;
                }
                else if (dZ > dY) {
                    iZ = -iX - iY;
                }
		    }

            return CoordinatesService.Create(iX, iZ);
        }
    }
}