using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {
    public int x;
    public int y;
    private Monster me;
    private GridMove gm;
    // Use this for initialization
    void Start()
    {
        me = new Monster(Board.Instance, x, y);
        gm = GetComponent<GridMove>();
        gm.SetMe(me, false);
    }

    void Update()
    {
        gm.Move();
    }
}
