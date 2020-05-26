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
    }
}
