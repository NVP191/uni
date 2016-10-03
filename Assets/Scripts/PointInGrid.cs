using UnityEngine;
using System.Collections;

public class PointInGrid {

	public Vector3 position = Vector3.zero;
	public int xGrid = 0;
	public int yGrid = 0;
	public bool empty = true;
	public bool canMove = true;
	public Transform tran;
	public int type;

	public void SetTran(Transform tran) {
		this.tran = tran;
		if (tran == null) {
			empty = true;
		} else {
			empty = false;
			type = 0;
		}
		try {
			this.tran.position = this.position;
		} catch {
			//
		}
	}

	public PointInGrid[] VisitNeighbor(PointInGrid[] points, PointInGrid point, GridPoint gridPoint) {

		int n = ArrLenght(points);

//		bool addPoint = false;
//
//		foreach (PointInGrid tempPoint in points) {
//			if(tempPoint.eq)
//		}

		PointInGrid[] arrPoints = new PointInGrid[n + 1];
		for (int i = 0; i < n; i++) {
			arrPoints[i] = points[i];
		}
		arrPoints[n] = point;
		points = arrPoints;

		if (ArrLenght(arrPoints) == 3) {
			
			return points;
		}

		PointInGrid rightNeighbor = gridPoint.GetPoint(point.xGrid + 1, point.yGrid);
		PointInGrid leftNeighbor = gridPoint.GetPoint(point.xGrid - 1, point.yGrid);
		PointInGrid belowNeighbor = gridPoint.GetPoint(point.xGrid, point.yGrid - 1);
		PointInGrid aboveNeighbor = gridPoint.GetPoint(point.xGrid, point.yGrid + 1);

		if (rightNeighbor.type == point.type && rightNeighbor.xGrid != point.xGrid && !rightNeighbor.empty) {
			
			return VisitNeighbor(points, rightNeighbor, gridPoint);
		}

//		if (leftNeighbor.type == point.type && leftNeighbor.xGrid != point.xGrid && !leftNeighbor.empty) {
//			
//			return VisitNeighbor(points, leftNeighbor, gridPoint);
//		}
//
//		if (belowNeighbor.type == point.type && belowNeighbor.xGrid != point.xGrid && !belowNeighbor.empty) {
//
//			return VisitNeighbor(points, belowNeighbor, gridPoint);
//		}
//
//		if (aboveNeighbor.type == point.type && aboveNeighbor.xGrid != point.xGrid && !aboveNeighbor.empty) {
//
//			return VisitNeighbor(points, aboveNeighbor, gridPoint);
//		}

		return null;
	}



	public PointInGrid() {

	}

	public PointInGrid(Vector3 position, int xGrid, int yGrid) {
		this.position = position;
		this.xGrid = xGrid;
		this.yGrid = yGrid;
	}

	private int ArrLenght(PointInGrid[] obj) {
	
		int lenght = 0;
	
		try {
			while (true) {
				PointInGrid checker = obj[lenght];
				lenght++;
			}
		} catch {
			//
		}
	
		return lenght;
	}
}
