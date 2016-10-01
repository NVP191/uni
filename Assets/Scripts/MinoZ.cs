using UnityEngine;
using System.Collections;

public class MinoZ : MonoBehaviour {

	public PointInGrid point;
	public bool canMove = true;

	public void SetPoint(PointInGrid point) {
		this.point = point;
	}

}