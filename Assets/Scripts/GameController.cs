using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyDown;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public int powerUpCount;
	public float spawnTimer;
	public bool spawnTop;
	public bool spawnAlternate;
	public float waveTimer;
	public float powerUpTimer;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver = false;
	private bool restart = false;
	private GameObject enemyObject;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		Debug.Log ("Score Value: " + GameState.score);

		UpdateScore ();

		StartCoroutine (spawnPowerUps ());

		if (Application.loadedLevelName != "test-bed") {
			StartCoroutine (spawnWaves ());
		}
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

				if (spawnAlternate){
					if (spawnTop){
						spawnTop = false;
					}else{
						spawnTop = true;
					}
				}

				if (spawnTop){
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					enemyObject = enemyDown;
				} else {
					enemyObject = enemy;
				}

				Quaternion spawnRotation = Quaternion.identity;
			
				Instantiate (enemyObject, spawnPosition, spawnRotation);

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
		GameState.score += newScore;
		Debug.Log ("New Score: " + GameState.score);
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + GameState.score;
		Debug.Log ("Updated Score: " + GameState.score);
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOver = true;
	}

}
