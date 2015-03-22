using UnityEngine;
using System.Collections;

public class GrowController : MonoBehaviour {

	private GameObject player;
	public GrowPowerUpHandler growPowerUpHandler;
	private GrowPowerUpHandler powerUpObject;

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

			powerUpObject = Instantiate(growPowerUpHandler, new Vector3(0f, 0f, 0f), playerQuaternion) as GrowPowerUpHandler;

			powerUpObject.StartCoroutine(powerUpObject.objectScale(player));

			Destroy(gameObject);
		}
	}
}
