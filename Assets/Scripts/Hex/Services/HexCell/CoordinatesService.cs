using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class CoordinatesService
    {
        public static HexCoordinates GetCoordinatesFromPosition(float3 position)
        {
            float x = position.x / (HexMetrics.innerRadius * 2f);
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

            return new HexCoordinates {
                Value = new int3(
                    iX,
                    iX - iZ,
                    iZ
                )
            };
        }
    }
}