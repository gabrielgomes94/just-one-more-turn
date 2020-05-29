using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class HexCellFinder
    {
        public static NativeArray<ColorComponent> GetColorsComponentsArray(EntityQuery query)
        {
            return query.ToComponentDataArray<ColorComponent>(Allocator.Temp);
        }

        public static NativeArray<HexCoordinates> GetHexCoordinatesArray(EntityQuery query)
        {
            return query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);
        }

        public static Color GetColorByIndex(EntityQuery query, int index)
        {
            NativeArray<ColorComponent> colorComponentsArray = HexCellFinder.GetColorsComponentsArray(query);
            Color color = colorComponentsArray[index].Value;

            colorComponentsArray.Dispose();

            return color;
        }
    }
}
