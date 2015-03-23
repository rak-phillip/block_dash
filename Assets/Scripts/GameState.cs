using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int score = 0;

	public enum StageState {
		Stage1,
		Stage2,
		Stage3,
		Stage4
	};

	public static StageState stageState = StageState.Stage1;

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

	}
}
