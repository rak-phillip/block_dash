using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyDown;
	public GameObject enemyBottom;
	public GameObject powerUp;
	public GameObject powerDownSpeed;
	public GameObject powerUpSpeed;
	public GameObject powerUpGrow;
	public GameObject powerUpShrink;
	public Vector3 spawnValues;
	public int hazardCount;
	public int powerUpCount;
	public float spawnTimer;
	public bool spawnTop;
	public bool spawnBottom;
	public bool spawnAlternate;
	public float waveTimer;
	public float powerUpTimer;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText livesText;
	public GUIText mainMenuText;
	private bool gameOver = false;
	private bool restart = false;
	private GameObject enemyObject;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		mainMenuText.text = "";
		Debug.Log ("Score Value: " + GameState.score);

		UpdateScore ();
		UpdateLives ();

		spawnRandomPowerUps ();
		StartCoroutine (spawnPowerUps ());

		if (Application.loadedLevelName != "test-bed") {
			StartCoroutine (spawnWaves ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				GameState.resetScore();
				GameState.resetLives();
				Application.LoadLevel(Application.loadedLevel);
			}
			if (Input.GetKeyDown(KeyCode.M)) {
				GameState.resetScore();
				GameState.resetLives();
				Application.LoadLevel("main-menu");
			}
		}
	}

	IEnumerator spawnWaves () {

		yield return new WaitForSeconds (waveTimer);

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
				} else if (spawnBottom) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, spawnValues.z);
					enemyObject = enemyBottom;
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
				mainMenuText.text = "Press 'M' for Main Menu";
				restart = true;
				break;
			}
		}
	}

	/// <summary>
	/// Spawns power ups.
	/// </summary>
	/// <returns>The power ups.</returns>
	IEnumerator spawnPowerUps () {

		for (int x = 0; x < powerUpCount; x++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),
				                                     Random.Range (-spawnValues.y, spawnValues.y));
			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (powerUp, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (powerUpTimer);
		}
	}
	
	/// <summary>
	/// Spawns three random power ups.
	/// </summary>
	/// <returns>The random power ups.</returns>
	private void spawnRandomPowerUps () {
		
		for (int x = 0; x < 3; x++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),
			                                     Random.Range (-spawnValues.y, spawnValues.y));
			Quaternion spawnRotation = Quaternion.identity;
			
			//pick a random number 0-3 and spawn the matching powerup
			int rand = Random.Range(0, 4);

			Debug.Log("Random Number: " + rand);

			if (rand.Equals (0)){
				Instantiate (powerUpSpeed, spawnPosition, spawnRotation);
			}else if (rand.Equals(1)){
				Instantiate (powerDownSpeed, spawnPosition, spawnRotation);
			}else if (rand.Equals(2)){
				Instantiate (powerUpGrow, spawnPosition, spawnRotation);
			}else{
				Instantiate (powerUpShrink, spawnPosition, spawnRotation);
			}
		}	
	}

	public void AddScore(int newScore) {
		GameState.score += newScore;
		Debug.Log ("New Score: " + GameState.score);
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + GameState.score;
	}

	public void RemoveLives() {
		GameState.lives--;
		UpdateLives ();
	}

	void UpdateLives() {
		livesText.text = "Lives: " + GameState.lives;
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public void startGame() {
		Application.LoadLevel ("main");
	}

	public void exitGame() {
		Application.Quit ();
	}

}
