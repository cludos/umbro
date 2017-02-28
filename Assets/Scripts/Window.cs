using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowRay : Ray {
	private int range = 20;
	private Vector2 dir;
	private Vector2 pos;

	public windowRay(int range, Vector2 dir, Vector2 pos) {
		this.dir = dir;
		this.pos = pos - dir;
	}

	public bool hasNextLight() {
		return range > 0;
	}

	public Vector2 nextLight () {
		int height = Board.Instance.GetHeight((int)pos.x, (int)pos.y);

        while (height > 0)
        {
            range--;
            pos += dir;
            height = Mathf.Max(Board.Instance.GetHeight((int)pos.x, (int)pos.y), height);
            height--;

        }
        range--;
        pos += dir;

        return pos;
	}
}


public class Window : LightSource {
	public int range;
	public Vector2 dir;



	public override Ray getPath() {
		return new windowRay(range, dir, new Vector2(x,y));
	}

    public override void setPower(bool power)
    {
        base.setPower(power);
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.enabled = !power;
    }
}
