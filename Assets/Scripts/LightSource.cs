﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ray {
	bool hasNextLight();
	Vector2 nextLight();
}

public class simpleRay : Ray {
	public bool hasNextLight() {
		return false;
	}

	public Vector2 nextLight () {
		return new Vector2(-1,-1);
	}
}

public class LightSource : MonoBehaviour {
    private Board board;

	// Use this for initialization
	void Start () {
		board = Board.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = getPath();
		while (ray.hasNextLight()) {
			Vector2 lightLocation = ray.nextLight();
		    board.SetLight(true, (int)lightLocation.x, (int)lightLocation.y);
		}
	}

	public Ray getPath() {
		return new simpleRay();
	}
}