using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int score = 0;
	public static int lives = 3;

	public enum StageState {
		Stage1,
		Stage2,
		Stage3,
		Stage4,
		GameOver
	};

	public static StageState stageState = StageState.Stage1;
	private Vector2 spawnValues = new Vector2(18f, 4.7f);

	public static void loadStage(){
		if (stageState.Equals(StageState.Stage1)){
			Application.LoadLevel("stage-2");
			stageState = StageState.Stage2;
			return;
		}

		if (stageState.Equals(StageState.Stage2)){
			Application.LoadLevel("stage-3");
			stageState = StageState.Stage3;
			return;
		}

		if (stageState.Equals(StageState.Stage3)){
			Application.LoadLevel("stage-4");
			stageState = StageState.Stage4;
			return;
		}

		if (stageState.Equals(StageState.Stage4)){
			Application.LoadLevel("game-over");
			stageState = StageState.GameOver;
			return;
		}
	}

	public static void resetLives() {
		lives = 3;
	}

	public static void resetScore() {
		score = 0;
	}

	public static void resetState() {
		stageState = StageState.Stage1;
	}
}
