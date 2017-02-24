using UnityEngine;
using System.Collections;

public class GridMoveK : MonoBehaviour {
    public float speed = 2.0f;
    private Vector3 pos;
    private Transform tr;
    public int x;
    public int y;
    private Board board;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        tr = transform;
        board = Board.Instance;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow) && tr.position == pos && board.KidCanMove(x+1, y))
        {
            pos += Vector3.right;
            board.SetBlocking(false, x, y);
            x += 1;
            board.SetBlocking(true, x, y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && tr.position == pos && board.KidCanMove(x - 1, y))
        {
            pos += Vector3.left;
            board.SetBlocking(false, x, y);
            x -= 1;
            board.SetBlocking(true, x, y);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && tr.position == pos && board.KidCanMove(x, y+1))
        {
            pos += Vector3.forward;
            board.SetBlocking(false, x, y);
            y += 1;
            board.SetBlocking(true, x, y);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && tr.position == pos && board.KidCanMove(x, y-1))
        {
            pos += Vector3.back;
            board.SetBlocking(false, x, y);
            y -= 1;
            board.SetBlocking(true, x, y);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
