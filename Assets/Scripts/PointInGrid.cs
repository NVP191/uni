using UnityEngine;
using System.Collections;

public class PointInGrid {

	public Vector3 position = Vector3.zero;
	public int xGrid = 0;
	public int yGrid = 0;
	public bool empty = true;
	public Transform tran;

	public void SetTran(Transform tran) {
		this.tran = tran;
		try {
			tran.position = this.position;
		} catch {
			//
		}
	}

	public PointInGrid() {

	}

	public PointInGrid(Vector3 position) {
		this.position = position;
	}

	public PointInGrid(Vector3 position, int xGrid, int yGrid) {
		this.position = position;
		this.xGrid = xGrid;
		this.yGrid = yGrid;
	}
}
