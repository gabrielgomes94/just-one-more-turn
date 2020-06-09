﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hex
{
    public class PositionCalculator
    {
        public static int GetOffsetX(int x, int z)
        {
            return x - z / 2;
        }

        public static float GetPositionX(int x, int z)
        {
            return (x + (z * 0.5f) - (z / 2)) * (HexMetrics.innerRadius * 2f);
        }

        public static float GetPositionY(int elevation)
        {
            return elevation * HexMetrics.elevationStep;
        }

        public static float GetPositionZ(int z)
        {
            return z * (HexMetrics.outerRadius * 1.5f);
        }
    }
}