using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;

	HexCell[] cells;

	public Text cellLabelPrefab;

	Canvas gridCanvas;

	void Awake()
	{
		gridCanvas = GetComponentInChildren<Canvas>();
		cells = InstantiateHexCellsArray();

		CreateCells();
	}

	void CreateCell(int x, int z, int i)
	{
		Vector3 position = GetCellPosition(x, z);
		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);

		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;

		PrintCellCoordinates(position, x, z);
		
	}

	private HexCell[] InstantiateHexCellsArray()
    {
		return new HexCell[height * width];
	}

	private void CreateCells()
    {
		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				CreateCell(x, z, i++);
			}
		}
	}

	private Vector3 GetCellPosition(int x, int z)
    {
		Vector3 position;

		position.x = (x + (z * 0.5f) - (z / 2)) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		return position;
	}

	private void PrintCellCoordinates(Vector3 position, int x, int z)
    {
		Text label = Instantiate<Text>(cellLabelPrefab);

		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
		label.text = x.ToString() + "\n" + z.ToString();
	}
}
