using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    public int x;
    public int y;
    private Exit me;


    // Use this for initialization
    void Start()
    {
        me = new Exit(Board.Instance, x, y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}