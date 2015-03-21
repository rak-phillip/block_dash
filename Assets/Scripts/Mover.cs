using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody2D movingObject;

	// Use this for initialization
	void Start () {
	
		movingObject = GetComponent<Rigidbody2D> ();

		movingObject.velocity = new Vector2(-10f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
