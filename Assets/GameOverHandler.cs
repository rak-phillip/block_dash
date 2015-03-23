using UnityEngine;
using System.Collections;

public class GameOverHandler : MonoBehaviour {

	public GUIText finalScoreText;

	// Use this for initialization
	void Start () {
	
		finalScoreText.text = "Final Score: " + GameState.score;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
