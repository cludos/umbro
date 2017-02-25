using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidScript : MonoBehaviour {
    public int x;
    public int y;
    private Kid me;
    private GridMove gm;
	// Use this for initialization
	void Start () {
        me = new Kid(Board.Instance, x, y);
        gm = GetComponent<GridMove>();
        gm.SetMe(me, true);
    }

    void Update ()
    {
        gm.Move();
    }

    public int getX()
    {
        return me.x;
    }

    public int getY()
    {
        return me.y;
    }

}
