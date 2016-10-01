using UnityEngine;
using System.Collections;

public class GridPoint {

	public float width = 1f;
	public int xLenght;
	public int yLenght;
	public PointInGrid originPoint = new PointInGrid(Vector3.zero);
	public PointInGrid[,] gridPoint;

	public GridPoint(int xLenght, int yLenght) {
		this.xLenght = xLenght;
		this.yLenght = yLenght;
		GeneratePoint();
	}

	public GridPoint(int xLenght, int yLenght, float width) {
		this.xLenght = xLenght;
		this.yLenght = yLenght;
		this.width = width;
		GeneratePoint();
	}

	public GridPoint(int xLenght, int yLenght, float width, PointInGrid originPoint) {
		this.xLenght = xLenght;
		this.yLenght = yLenght;
		this.width = width;
		this.originPoint = originPoint;
		GeneratePoint();
	}

	private void GeneratePoint() {
		gridPoint = new PointInGrid[xLenght, yLenght];
		for (int i = 0; i < xLenght; i++) {
			for (int j = 0; j < yLenght; j++) {
				float x = width * (i + 1) - width / 2 + originPoint.position.x;
				float y = width * (j + 1) - width / 2 + originPoint.position.y;
				Vector3 pos = new Vector3(x, y, 0);
				PointInGrid pointInGrid = new PointInGrid(pos, i + 1, j + 1);
				gridPoint[i, j] = pointInGrid;
			}
		}
	}

	public PointInGrid GetPoint(int xGrid, int yGrid) {
		if (xGrid > xLenght || yGrid > yLenght || xGrid < 1 || yGrid < 1) {
			if (xGrid > xLenght) {
				return gridPoint[xLenght - 1, yGrid - 1];
			} else
			if (yGrid > yLenght) {
				return gridPoint[xGrid - 1, yLenght - 1];
			} else
			if (xGrid < 1) {
				return gridPoint[0, yGrid - 1];
			} else
			if (yGrid < 1) {
				return gridPoint[xGrid - 1, 0];
			}
		}
		return gridPoint[xGrid - 1, yGrid - 1];
	}

	public void SetPoint(PointInGrid point) {
		gridPoint[point.xGrid - 1, point.yGrid - 1] = point;
	}
}

