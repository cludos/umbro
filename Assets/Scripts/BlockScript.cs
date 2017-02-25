using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int x;
    public int y;
    public int height;
    public float speed = 2f;
    private Block me;


    // Use this for initialization
    void Start () {
        me = new Block(Board.Instance, x, y, height);
    }

    // Update is called once per frame
    void Update () {
        int diffx = x - me.x;
        int diffy = y - me.y;

        if (diffx != 0 || diffy != 0) {
            Vector3 newPos = transform.position + (Vector3.right * -diffx + Vector3.forward * -diffy);
            transform.position = newPos;//update to make animated later Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);

            x = me.x;
            y = me.y;
        }

    }
}
