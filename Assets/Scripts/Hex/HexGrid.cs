using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;

	HexCell[] cells;

	void Awake()
	{
		cells = InstantiateHexCellsArray();

		CreateCells();
	}

	void CreateCell(int x, int z, int i)
	{
		Vector3 position = GetCellPosition(x, z);
		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);

		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
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
		position.x = x * 10f;
		position.y = 0f;
		position.z = z * 10f;

		return position;
	}
}
