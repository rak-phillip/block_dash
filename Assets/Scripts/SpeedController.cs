using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour {

	public PowerUpHandler powerUpHandler;
	public int powerUpSpeed;
	public float powerDownTimer;
	
	private GameObject player;
	private PowerUpHandler powerUpObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("Player")) {
			
			player = other.gameObject;
			
			Quaternion playerQuaternion = Quaternion.identity;
			
			powerUpObject = Instantiate(powerUpHandler, new Vector3(0f, 0f, 0f), playerQuaternion) as PowerUpHandler;
			
			powerUpObject.StartCoroutine(powerUpObject.objectSpeed(player, powerUpSpeed, powerDownTimer));
			
			Destroy(gameObject);
		}
	}
}
