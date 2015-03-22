using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public int scoreValue;
	public float speed; //public modifier can be accessed directly from unity
	public Boundary boundary;
	private Rigidbody2D player; //player object
	private GameController gameController;

	// Use this for initialization
	void Start () {
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

	void FixedUpdate () {

		//get the horizontal and vertical input
		float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		//define the player movement
		Vector2 movement = new Vector2 (movementHorizontal, movementVertical);

		//get the player object
		player = GetComponent<Rigidbody2D> ();

		//apply the player movement
		player.velocity = movement * speed;

		//constrain the player to the scene
		player.position = new Vector2 (
			Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax)
			);

		//when the player connects with the right side of the screen, reset position
		if (player.position.x.Equals(boundary.xMax)) {
			player.MovePosition(new Vector2(boundary.xMin, 0f));
			gameController.AddScore(scoreValue);
			loadStage();
		}

	}

	void loadStage() {

		if (Application.loadedLevelName.Equals("test-bed")) {
			Application.LoadLevel("main");
		}

	}
}
