using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugScript : MonoBehaviour {

    public int x;
    public int y;
    private Rug me;


    // Use this for initialization
    void Start()
    {
        me = new Rug(Board.Instance, x, y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
