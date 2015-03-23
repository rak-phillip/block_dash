﻿using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	private static MusicHandler instance = null;

	public static MusicHandler Instance {
		get { return instance; }
	}

	void Awake() {

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
