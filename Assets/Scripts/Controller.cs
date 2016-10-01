using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Game game;

	void Start() {
		game = GameObject.Find("Game").GetComponent<Game>();

	}

	void Update() {
		game.GenerateMino();
		game.MinoMoveInGrid();
	}
}
