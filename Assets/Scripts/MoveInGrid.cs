using UnityEngine;
using System.Collections;

public class MoveInGrid {

	public static void Rotate(GridPoint gridPoint, MinoZ mino1, MinoZ mino2) {
		
	}

	public static void Up(GridPoint gridPoint, MinoZ minoZ) {
		Move(gridPoint, minoZ, 0, 1);
	}

	public static void Down(GridPoint gridPoint, MinoZ minoZ) {
		Move(gridPoint, minoZ, 0, -1);
	}

	public static void Right(GridPoint gridPoint, MinoZ minoZ) {
		Move(gridPoint, minoZ, 1, 0);
	}

	public static void Left(GridPoint gridPoint, MinoZ minoZ) {
		Move(gridPoint, minoZ, -1, 0);
	}

	private static void Move(GridPoint gridPoint, MinoZ minoZ, int xStep, int yStep) {
		PointInGrid fromPoint = minoZ.point;
		PointInGrid toPoint = null;

		if (fromPoint.xGrid <= gridPoint.xLenght && fromPoint.yGrid <= gridPoint.yLenght && minoZ.canMove) {
			
			fromPoint = gridPoint.GetPoint(fromPoint.xGrid, fromPoint.yGrid);
			toPoint = gridPoint.GetPoint(fromPoint.xGrid + xStep, fromPoint.yGrid + yStep);

			if (toPoint.empty) {

				toPoint.SetTran(minoZ.transform);
				toPoint.empty = false;

				fromPoint.SetTran(null);
				fromPoint.empty = true;

				minoZ.SetPoint(toPoint);
			}

			if (fromPoint.yGrid == 1 || !gridPoint.GetPoint(minoZ.point.xGrid, minoZ.point.yGrid - 1).empty) {
				minoZ.canMove = false;

			}
		}
	}
}
