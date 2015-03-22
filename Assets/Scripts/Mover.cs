using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public Vector2 direction;
	private Rigidbody2D movingObject;

	// Use this for initialization
	void Start () {
	
		movingObject = GetComponent<Rigidbody2D> ();

		movingObject.velocity = direction;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
