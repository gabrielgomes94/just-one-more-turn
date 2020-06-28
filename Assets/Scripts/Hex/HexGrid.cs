using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hex
{
    public class HexGrid : MonoBehaviour
    {
        public int width = 6;
        public int height = 6;

        public Text cellLabelPrefab;
        Canvas gridCanvas;

        void Awake()
        {
            gridCanvas = GetComponentInChildren<Canvas>();
        }

        void Start()
        {
            HexCellEntity cellEntity = new HexCellEntity();
            cellEntity.CreateCells(width, height);

            AddTextCoordinatesOnGrid(width, height);
        }

        void AddTextCoordinatesOnGrid(int width, int height)
        {
            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    Text label = Instantiate<Text>(cellLabelPrefab);

                    label.rectTransform.SetParent(gridCanvas.transform, false);
                    label.rectTransform.anchoredPosition = new Vector2(
                        PositionCalculator.GetPositionX(x, z),
                        PositionCalculator.GetPositionZ(z)
                    );

                    HexCoordinates coordinates = CoordinatesService.CreateFromOffset(x, z);
                    label.text = "" + coordinates.Value.x + ", " + coordinates.Value.y + ", " + coordinates.Value.z + "";
                }
            }
        }
    }
}
