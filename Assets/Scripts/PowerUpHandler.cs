using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour {
	
	private Rigidbody2D player;
	private PlayerController playerController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator objectScale(GameObject playerObject, Vector3 powerUpScale, float powerDownTimer){
		
		playerObject.transform.localScale = powerUpScale;
		
		Debug.Log ("Starting Timer");
		
		yield return new WaitForSeconds (powerDownTimer);
		
		Debug.Log ("Timer Finished");
		
		playerObject.transform.localScale = new Vector3(1f, 1f, 1f);
		
		Destroy (gameObject);
	}
	
	public IEnumerator objectSpeed(GameObject playerObject, int speed, float powerDownTimer){
		
		playerController = playerObject.GetComponent<PlayerController> ();
		
		float originalSpeed = playerController.speed;
		
		Debug.Log ("Original Speed: " + originalSpeed);
		
		playerController.speed = speed;
		
		yield return new WaitForSeconds (powerDownTimer);
		
		playerController.speed = originalSpeed;
		
	}
}
