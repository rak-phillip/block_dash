using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (900, 300, false);

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log("FAIL: Unable to find 'GameController' script.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals ("Boundary") || 
		    other.tag.Equals("Enemy") || 
		    other.tag.Equals("PowerUp") ||
		    tag.Equals("PowerUp")){
			Debug.Log("TAG: " + tag);
			return;
		}

		if (other.tag.Equals("Player")) {
			gameController.RemoveLives();
			if (GameState.lives <= 0) {
				gameController.livesText.text = "";
				gameController.GameOver();
			} else {
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
