using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowRay : Ray {
	private int range = 20;
	private Vector2 dir;
	private Vector2 pos;

	public windowRay(int range, Vector2 dir, Vector2 pos) {
		this.dir = dir;
		this.pos = pos;
	}

	public bool hasNextLight() {
		return range > 0;
	}

	public Vector2 nextLight () {
		int height = Board.Instance.GetHeight((int)pos.x, (int)pos.y);
		range -= (height+1);
		pos += dir * (height+1);
		return pos;
	}
}


public class Window : LightSource {
	public int range;
	public Vector2 dir;


	public new Ray getPath() {
		return new windowRay(range, dir, transform.position);
	}
}
