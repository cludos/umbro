using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {
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

        if (Input.GetKeyDown(KeyCode.D) && tr.position == pos && board.MonsterCanMove(x + 1, y))
        {
            pos += Vector3.right;
            x += 1;

        }
        else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos && board.MonsterCanMove(x - 1, y))
        {
            pos += Vector3.left;
            x -= 1;

        }
        else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos && board.MonsterCanMove(x, y + 1))
        {
            pos += Vector3.forward;
            y += 1;

        }
        else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos && board.MonsterCanMove(x, y - 1))
        {
            pos += Vector3.back;
            y -= 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
