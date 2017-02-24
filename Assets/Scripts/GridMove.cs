using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {
    public float speed = 2.0f;
    private Vector3 pos;
    private Transform tr;
    private KeyCode up;
    private KeyCode right;
    private KeyCode left;
    private KeyCode down;
    private Moveable me;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        tr = transform;
    }

    public void SetMe(Moveable me, bool isKid)
    {
        this.me = me;
        if (!isKid)
        {
            up = KeyCode.W;
            left = KeyCode.A;
            down = KeyCode.S;
            right = KeyCode.D;
        }
        else
        {
            up = KeyCode.UpArrow;
            left = KeyCode.LeftArrow;
            down = KeyCode.DownArrow;
            right = KeyCode.RightArrow;
        }
    }

 
    public void Move () {
        if (me == null) return;
        if (Input.GetKeyDown(right) && tr.position == pos && me.Move(me.x + 1, me.y))
        {
            pos += Vector3.right;
        }
        else if (Input.GetKeyDown(left) && tr.position == pos && me.Move(me.x - 1, me.y))
        {
            pos += Vector3.left;
        }
        else if (Input.GetKeyDown(up) && tr.position == pos && me.Move(me.x, me.y + 1))
        {
            pos += Vector3.forward;
        }
        else if (Input.GetKeyDown(down) && tr.position == pos && me.Move(me.x, me.y - 1))
        {
            pos += Vector3.back;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
