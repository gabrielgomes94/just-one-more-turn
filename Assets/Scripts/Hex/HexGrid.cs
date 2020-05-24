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

        public HexCell cellPrefab;

        public Text cellLabelPrefab;
        Canvas gridCanvas;
        HexMesh hexMesh;

        void Awake()
        {
            gridCanvas = GetComponentInChildren<Canvas>();
        }

        void Start()
        {
            HexCellEntity cellEntity = new HexCellEntity();
            cellEntity.CreateCells(width, height);
        }

        private void PrintCellCoordinates(Vector3 position, HexCell cell)
        {
            HexCoordinates coordinates = cell.coordinates;
            Text label = Instantiate<Text>(cellLabelPrefab);

            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);

            label.text = coordinates.X.ToString() + "\n" + coordinates.Z.ToString();
            label.text = coordinates.ToStringOnSeparateLines();
        }
    }
}
