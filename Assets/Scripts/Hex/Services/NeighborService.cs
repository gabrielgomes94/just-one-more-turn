using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

namespace Hex
{
    public class NeighborService
    {
        int[,] hexCoordinatesModifier = new int [,] {
            {0, -1, 1},
            {1, -1, 0},
            {1, 0, -1},
            {0, 1, -1},
            {-1, 1, 0},
            {-1, 0, 1}
        };

        private HexCoordinates hexCellCoordinates;
        private ColorComponent hexCellColor;
        // private HexDirection direction;
        private NativeArray<ColorComponent> colorsComponentsArray;
        private NativeArray<HexCoordinates> hexCoordinatesArray;

        public NeighborService(
            HexCoordinates hexCellCoordinates,
            ColorComponent hexCellColor,
            NativeArray<ColorComponent> colorsComponentsArray,
            NativeArray<HexCoordinates> hexCoordinatesArray
        ) {
            this.hexCellCoordinates = hexCellCoordinates;
            this.hexCellColor = hexCellColor;
            this.colorsComponentsArray = colorsComponentsArray;
            this.hexCoordinatesArray = hexCoordinatesArray;
        }

        public Color GetNeighborColor(HexDirection direction) {
            Color color = this.hexCellColor.Value;

            int index = GetNeighborIndex(direction);

            if (index >= 0) {
                color = colorsComponentsArray[index].Value;
            }

            return color;
        }

        public int GetNeighborIndex(HexDirection direction) {
            HexCoordinates targetHexCoordinates = GetTargetHexCoordinates(direction);

            for (int i = 0; i < this.hexCoordinatesArray.Length; i++) {
                if (targetHexCoordinates == hexCoordinatesArray[i]) return i;
            }

            return -1;
        }

        private HexCoordinates GetTargetHexCoordinates(HexDirection direction)
        {
            return new HexCoordinates{
                X = this.hexCellCoordinates.X + this.hexCoordinatesModifier[(int) direction, 0],
                Y = this.hexCellCoordinates.Y + this.hexCoordinatesModifier[(int) direction, 1],
                Z = this.hexCellCoordinates.Z + this.hexCoordinatesModifier[(int) direction, 2]
            };
        }
    }
}
