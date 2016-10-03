using UnityEngine;
using System.Collections;

public class MoveInGrid {
	
	public static PointInGrid DownLeft(GridPoint gridPoint, PointInGrid fromPoint) {
		PointInGrid toPoint = Down(gridPoint, fromPoint);
		return Left(gridPoint, toPoint);
	}

	public static PointInGrid UpRight(GridPoint gridPoint, PointInGrid fromPoint) {
		PointInGrid toPoint = Up(gridPoint, fromPoint);
		return Right(gridPoint, toPoint);
	}

	public static PointInGrid Up(GridPoint gridPoint, PointInGrid fromPoint) {
		return Move(gridPoint, fromPoint, 0, 1);
	}

	public static PointInGrid Down(GridPoint gridPoint, PointInGrid fromPoint) {
		return Move(gridPoint, fromPoint, 0, -1);
	}

	public static PointInGrid Left(GridPoint gridPoint, PointInGrid fromPoint) {
		return Move(gridPoint, fromPoint, -1, 0);
	}

	public static PointInGrid Right(GridPoint gridPoint, PointInGrid fromPoint) {
		return Move(gridPoint, fromPoint, 1, 0);
	}

	// Di chuyen mot diem trong Grid xStep sang trai, yStep sang phai
	private static PointInGrid Move(GridPoint gridPoint, PointInGrid fromPoint, int xStep, int yStep) {

		// Kiem tra diem co kha nang di chuyen
		if (PointCanMove(gridPoint, fromPoint)) {

			PointInGrid toPoint = gridPoint.GetPoint(fromPoint.xGrid + xStep, fromPoint.yGrid + yStep);

			// Kiem tra vi tri di chuyen den
			if (toPoint.empty) {
				
				toPoint.SetTran(fromPoint.tran);
				toPoint.type = fromPoint.type;

				fromPoint.SetTran(null);

				// Diem mat kha nang di chuyen neu no den hang cuoi cua Grid
				// hoac diem duoi no khong con trong va trang thai canMove cua diem duoi no = false
				if (toPoint.yGrid == 1 || (!gridPoint.GetPoint(toPoint.xGrid, toPoint.yGrid - 1).empty
				    && !gridPoint.GetPoint(toPoint.xGrid, toPoint.yGrid - 1).canMove)) {
					
					toPoint.canMove = false;

				}
				return toPoint;
			}
		}
		return fromPoint;
	}

	// Kiem tra mot diem trong Grid co kha nang di chuyen hay khong
	private static bool PointCanMove(GridPoint gridPoint, PointInGrid point) {
		if (point.xGrid <= gridPoint.xGrid && point.yGrid <= gridPoint.yGrid && point.canMove) {
			return true;
		}
		return false;
	}
}
