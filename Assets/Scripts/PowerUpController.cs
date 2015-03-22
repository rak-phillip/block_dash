using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (tag.Equals("PowerUp") && other.tag.Equals("Player")) {
			Destroy(gameObject);
			return;
		}
	}
}
