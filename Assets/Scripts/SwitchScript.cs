using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public int x;
    public int y;
    public KidScript kid;
    public List<LightSource> lights;
    private Switch me;

	// Use this for initialization
	void Start () {
        me = new Switch(Board.Instance, x, y, lights);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightShift) && kid.getX() == x && kid.getX() == y)
        {
            me.toggleLights();
        }
	}

}
