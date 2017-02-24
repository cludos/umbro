using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {
    public float speed = 2.0f;
    private Vector3 pos;
    private Transform tr;
    public int x;
    public int y;
    public bool useWASD;
    private Board board;
    private KeyCode up;
    private KeyCode right;
    private KeyCode left;
    private KeyCode down;
    private Moveable me;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        tr = transform;
        board = Board.Instance;
        if (useWASD)
        {
            me = board.monster;
            up = KeyCode.W;
            left = KeyCode.A;
            down = KeyCode.S;
            right = KeyCode.D;
        } else
        {
            me = board.kid;
            up = KeyCode.UpArrow;
            left = KeyCode.LeftArrow;
            down = KeyCode.DownArrow;
            right = KeyCode.RightArrow;
        }
        Debug.Log("ME");
        Debug.Log(me);
    }

    // Update is called once per frame
    void Update () {
        if (me == null) me = useWASD ? (Moveable)board.monster : board.kid;


        if (Input.GetKeyDown(right) && tr.position == pos && me.CanMove(x + 1, y))
        {
            pos += Vector3.right;
            x += 1;

        }
        else if (Input.GetKeyDown(left) && tr.position == pos && me.CanMove(x - 1, y))
        {
            pos += Vector3.left;
            x -= 1;

        }
        else if (Input.GetKeyDown(up) && tr.position == pos && me.CanMove(x, y + 1))
        {
            pos += Vector3.forward;
            y += 1;

        }
        else if (Input.GetKeyDown(down) && tr.position == pos && me.CanMove(x, y - 1))
        {
            pos += Vector3.back;
            y -= 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
