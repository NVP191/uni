using UnityEngine;
using System.Collections;

public class GridPoint {

	public float width = 1f;
	public int xGrid;
	public int yGrid;
	public Vector3 originPoint = Vector3.zero;
	public PointInGrid[,] gridPoint;

	public GridPoint(int xGrid, int yGrid) {
		this.xGrid = xGrid;
		this.yGrid = yGrid;
		GeneratePoint();
	}

	public GridPoint(int xGrid, int yGrid, float width) {
		this.xGrid = xGrid;
		this.yGrid = yGrid;
		this.width = width;
		GeneratePoint();
	}

	public GridPoint(int xGrid, int yGrid, float width, Vector3 originPoint) {
		this.xGrid = xGrid;
		this.yGrid = yGrid;
		this.width = width;
		this.originPoint = originPoint;
		GeneratePoint();
	}

	private void GeneratePoint() {
		gridPoint = new PointInGrid[xGrid, yGrid];
		for (int i = 0; i < xGrid; i++) {
			for (int j = 0; j < yGrid; j++) {
				float x = width * (i + 1) - width / 2 + originPoint.x;
				float y = width * (j + 1) - width / 2 + originPoint.y;
				Vector3 pos = new Vector3(x, y, 0);
				PointInGrid pointInGrid = new PointInGrid(pos, i + 1, j + 1);
				gridPoint[i, j] = pointInGrid;
			}
		}
	}

	public PointInGrid GetPoint(int xGrid, int yGrid) {
		if (xGrid > this.xGrid || yGrid > this.yGrid || xGrid < 1 || yGrid < 1) {
			if (xGrid > this.xGrid) {
				return gridPoint[this.xGrid - 1, yGrid - 1];
			} else
			if (yGrid > this.yGrid) {
				return gridPoint[xGrid - 1, this.yGrid - 1];
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
}

