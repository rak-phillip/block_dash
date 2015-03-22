using UnityEngine;
using System.Collections;

public class GrowPowerUpHandler : MonoBehaviour {

	public Vector3 powerUpScale;
	public float powerDownTimer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator objectScale(GameObject playerObject){
		
		playerObject.transform.localScale = powerUpScale;
		
		Debug.Log ("Starting Timer");
		
		yield return new WaitForSeconds (powerDownTimer);
		
		Debug.Log ("Timer Finished");
		
		playerObject.transform.localScale = new Vector3(1f, 1f, 1f);

		Destroy (gameObject);
	}
}
