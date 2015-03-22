using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnTimer;

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawnWaves () {

		for (int x = 0; x < hazardCount; x++) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
			//Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			
			Instantiate (enemy, spawnPosition, spawnRotation);

			yield return new WaitForSeconds(spawnTimer);
		}
	}

}
