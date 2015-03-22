using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log("Unable to load the game controller object: PowerUpController.cs");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("Player")) {
			Destroy(gameObject);
			gameController.AddScore(300);
			return;
		}
	}

	void SpawnRandom(){

	}
}
