using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int x;
    public int y;
    public int height;
    private Block me;


    // Use this for initialization
    void Start () {
        me = new Block(Board.Instance, x, y, height);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
