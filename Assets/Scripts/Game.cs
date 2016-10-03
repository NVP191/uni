using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GridPoint gridPoint;
	public Transform minoZ;
	public Transform minoT;
	private PointInGrid point1;
	private PointInGrid point2;
	private int minoType;

	public bool generateMino = false;

	// Use this for initialization
	void Start() {
		
		gridPoint = new GridPoint(6, 6, 1.5f);
	}

	// Khoi tao Mino (2 Mino)
	public void GenerateMino() {
		
		if (generateMino) {
			Transform mino = GenMino();
			SetMinoToGrid(mino, 2, 6);
			point1 = gridPoint.GetPoint(2, 6);

			mino = GenMino();
			SetMinoToGrid(mino, 3, 6);
			point2 = gridPoint.GetPoint(3, 6);

			generateMino = false;
		}
	}

	// Set Mino vao Grid
	private void SetMinoToGrid(Transform mino, int i, int j) {
		gridPoint.GetPoint(i, j).SetTran(mino);
		gridPoint.GetPoint(i, j).type = minoType;
	}

	// Sinh ngau nhien mot trong cac Mino
	private Transform GenMino() {
		if (Random.value < 0.5) {
			minoType = 1;
			return Instantiate(minoZ);
		} else {
			minoType = 2;
			return Instantiate(minoT);
		}
	}

	// Di chuyen Mino trong Grid
	public void MinoMoveInGrid() {

		// Di len
		if (Input.GetKeyDown(KeyCode.W)) {
			if (point1.yGrid > point2.yGrid) {
				point1 = MoveInGrid.Up(gridPoint, point1);
				point2 = MoveInGrid.Up(gridPoint, point2);
			} else {
				point2 = MoveInGrid.Up(gridPoint, point2);
				point1 = MoveInGrid.Up(gridPoint, point1);
			}
		} else
		// Di xuong
		if (Input.GetKeyDown(KeyCode.S)) {
			if (point1.yGrid > point2.yGrid) {
				point2 = MoveInGrid.Down(gridPoint, point2);
				point1 = MoveInGrid.Down(gridPoint, point1);
			} else {
				point1 = MoveInGrid.Down(gridPoint, point1);
				point2 = MoveInGrid.Down(gridPoint, point2);
			}
		} else
		// Sang trai
		if (Input.GetKeyDown(KeyCode.A)) {
			if (point1.xGrid > point2.xGrid) {
				point2 = MoveInGrid.Left(gridPoint, point2);
				point1 = MoveInGrid.Left(gridPoint, point1);
			} else {
				point1 = MoveInGrid.Left(gridPoint, point1);
				point2 = MoveInGrid.Left(gridPoint, point2);
			}
		} else
		// Sang phai
		if (Input.GetKeyDown(KeyCode.D)) {
			if (point1.xGrid > point2.xGrid) {
				point1 = MoveInGrid.Right(gridPoint, point1);
				point2 = MoveInGrid.Right(gridPoint, point2);
			} else {
				point2 = MoveInGrid.Right(gridPoint, point2);
				point1 = MoveInGrid.Right(gridPoint, point1);
			}
		} else
						
		// Quay
		if (Input.GetKeyDown(KeyCode.Space)) {

			// Hai diem nam ngang
			if (point1.yGrid == point2.yGrid) {
								
				// Toa do diem nho hon co Grid thi moi cho quay
				if (point1.yGrid < gridPoint.yGrid && point2.yGrid < gridPoint.yGrid) {
					//diem 1 nam ben trai diem 2 thi quay diem 1 len tren
					if (point1.xGrid < point2.xGrid) {
						point1 = MoveInGrid.UpRight(gridPoint, point1);
					} else {
						point2 = MoveInGrid.UpRight(gridPoint, point2);
					}
				} else {
					if (point1.xGrid < point2.xGrid) {
						point2 = MoveInGrid.Down(gridPoint, point2);
						point1 = MoveInGrid.Right(gridPoint, point1);
					} else {
						point1 = MoveInGrid.Down(gridPoint, point1);
						point2 = MoveInGrid.Right(gridPoint, point2);
					}
				}
			} else
			// Hai diem nam doc
			if (point1.xGrid == point2.xGrid) {
				// Diem 1 nam tren diem 2
				if (point1.yGrid > point2.yGrid) {
					point2 = MoveInGrid.Left(gridPoint, point2);
					point1 = MoveInGrid.Down(gridPoint, point1);
				} else {
					point1 = MoveInGrid.Left(gridPoint, point1);	
					point2 = MoveInGrid.Down(gridPoint, point2);
				}
			}
		}

		// Khi hai diem co trang thai canMove = false thi dat trang thai co the sinh Mino = true
		if (!point1.canMove && !point2.canMove) {

			// An diem
			PointInGrid[] points;

			points = point1.VisitNeighbor(null, point1, gridPoint);
			GetScores(points);

			points = point2.VisitNeighbor(null, point2, gridPoint);
			GetScores(points);

			generateMino = true;
		}
	}

	// An diem
	private void GetScores(PointInGrid[] points) {
		if (ArrLenght(points) == 3) {
			
			Destroy(points[2].tran.gameObject);
			points[2].empty = true;
			points[2].type = 0;
			points[2].canMove = true;

			Destroy(points[1].tran.gameObject);
			points[1].empty = true;
			points[1].type = 0;
			points[1].canMove = true;

			UpdateColumn(points[2]);
			UpdateColumn(points[1]);
		}
	}

	// Sap xep lai column co phan tu bi destroy
	private void UpdateColumn(PointInGrid point) {
		
		int xColumn = point.xGrid;

		PointInGrid emptyPoint = null;

		for (int i = 1; i < gridPoint.yGrid; i++) {
			emptyPoint = gridPoint.GetPoint(xColumn, i);
			if (emptyPoint.empty) {
				break;
			}
		}

		if (emptyPoint != null) {
			
			for (int y = emptyPoint.yGrid + 1; y <= gridPoint.yGrid; y++) {

				PointInGrid tempPoint = gridPoint.GetPoint(xColumn, y);

				if (!tempPoint.empty) {
					
					tempPoint.canMove = true;

					while (tempPoint.canMove) {
						tempPoint = MoveInGrid.Down(gridPoint, tempPoint);
					}
				}
			}
		}
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
