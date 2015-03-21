using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public Vector3 spawnValues;

	// Use this for initialization
	void Start () {
		spawnWaves();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnWaves () {

		Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (enemy, spawnPosition, spawnRotation);
	}

}
