using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {
    public float speed = 2.0f;
    private Vector3 pos;
    private Transform tr;
    public GameObject board;
    public int x;
    public int y;
    private Board bds;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        tr = transform;
        bds = board.GetComponent<Board>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D) && tr.position == pos && bds.MonsterCanMove(x + 1, y))
        {
            pos += Vector3.right;
            board.GetComponent<Board>().SetOccupied("empty", x, y);
            x += 1;
            board.GetComponent<Board>().SetOccupied("monster", x, y);

        }
        else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos && bds.MonsterCanMove(x - 1, y))
        {
            pos += Vector3.left;
            board.GetComponent<Board>().SetOccupied("empty", x, y);
            x -= 1;
            board.GetComponent<Board>().SetOccupied("monster", x, y);

        }
        else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos && bds.MonsterCanMove(x, y + 1))
        {
            pos += Vector3.forward;
            board.GetComponent<Board>().SetOccupied("empty", x, y);
            y += 1;
            board.GetComponent<Board>().SetOccupied("monster", x, y);

        }
        else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos && bds.MonsterCanMove(x, y - 1))
        {
            pos += Vector3.back;
            board.GetComponent<Board>().SetOccupied("empty", x, y);
            y -= 1;
            board.GetComponent<Board>().SetOccupied("monster", x, y);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
