using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public int powerUpCount;
	public float spawnTimer;
	public float waveTimer;
	public float powerUpTimer;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public int score;
	private bool gameOver = false;
	private bool restart = false;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		Debug.Log ("Score Value: " + score);

		if (score <= 0) {
			score = 0;
		}

		UpdateScore ();

		StartCoroutine (spawnPowerUps ());

		//if (Application.loadedLevelName != "test-bed") {
			StartCoroutine (spawnWaves ());
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator spawnWaves () {

		while (true) {
			for (int x = 0; x < hazardCount; x++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				//Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
			
				Instantiate (enemy, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnTimer);
			}

			yield return new WaitForSeconds (waveTimer);

			if (gameOver) {
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}

	IEnumerator spawnPowerUps () {

		Debug.Log ("Starting Power Up Spawn");

		for (int x = 0; x < powerUpCount; x++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),
				                                     Random.Range (-spawnValues.y, spawnValues.y));
			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (powerUp, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (powerUpTimer);
		}
	}

	public void AddScore(int newScore) {
		score += newScore;
		Debug.Log ("New Score: " + score);
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
		Debug.Log ("Updated Score: " + score);
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOver = true;
	}

}
