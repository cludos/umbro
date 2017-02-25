using System.Collections;
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
    public int x;
    public int y;

    public bool isOn;
    private Board board;

	// Use this for initialization
	void Start () {
		board = Board.Instance;
        board.AddLightSource(this);
	}

    // Update is called once per frame
    // This may be better off only being called after board updates
    void Update () {
    }

    public void UpdateLights() {
        if (isOn) {
            Ray ray = getPath();
            while (ray.hasNextLight())
            {
                Vector2 lightLocation = ray.nextLight();
                board.SetLight(true, (int)lightLocation.x, (int)lightLocation.y);
            }
        }
    }

    public void setPower(bool power)
    {
        isOn = power;
    }

	public virtual Ray getPath() {
		return new simpleRay();
	}
}
