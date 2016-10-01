using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GridPoint gridPoint;
	public Transform minoZ;
	public Transform minoT;
	private MinoZ minoZComp;
	private MinoZ minoTComp;

	// Use this for initialization
	void Start() {
		gridPoint = new GridPoint(6, 6, 1.5f);

	}

	public void GenerateMino() {
		if (Input.GetKeyDown(KeyCode.B)) {
			Transform mino = GenMino();
			SetMinoToGrid(mino, 2, 6);

			mino = GenMino();
			SetMinoToGrid(mino, 3, 6);
		}
	}

	private void SetMinoToGrid(Transform mino, int i, int j) {
		gridPoint.GetPoint(i, j).SetTran(mino);
		if (i == 2) {
			minoZComp = mino.GetComponent<MinoZ>();
			minoZComp.SetPoint(gridPoint.GetPoint(i, j));
		} else
		if (i == 3) {
			minoTComp = mino.GetComponent<MinoZ>();
			minoTComp.SetPoint(gridPoint.GetPoint(i, j));
		}
	}

	private Transform GenMino() {
		if (Random.value < 0.5) {
			return Instantiate(minoZ);
		} else {
			return Instantiate(minoT);
		}
	}

	public void MinoMoveInGrid() {
		if (Input.GetKeyDown(KeyCode.W)) {
			MoveInGrid.Up(gridPoint, minoZComp);
			MoveInGrid.Up(gridPoint, minoTComp);
		} else
		if (Input.GetKeyDown(KeyCode.S)) {
			MoveInGrid.Down(gridPoint, minoZComp);
			MoveInGrid.Down(gridPoint, minoTComp);
		} else
		if (Input.GetKeyDown(KeyCode.A)) {
			MoveInGrid.Left(gridPoint, minoZComp);
			MoveInGrid.Left(gridPoint, minoTComp);
		} else
		if (Input.GetKeyDown(KeyCode.D)) {
			MoveInGrid.Right(gridPoint, minoTComp);
			MoveInGrid.Right(gridPoint, minoZComp);
		}
	}
}
