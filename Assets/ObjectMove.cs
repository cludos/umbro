using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {
    public float speed = 2.0f;
    private Vector3 pos;
    private Transform tr;
    public GameObject board;
    public int x;
    public int y;
    private Board bds;
    bool shift;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        tr = transform;
        bds = board.GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }
        if (shift)
        {
            if (Input.GetKeyDown(KeyCode.D) && tr.position == pos && bds.ObjectCanMove(x + 1, y) && (bds.boardoccupied[x - 1, y] == "monster" || bds.boardoccupied[x + 1, y] == "monster"))
            {
                pos += Vector3.right;
                bds.SetOccupied("empty", x, y);
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                x += 1;
                bds.SetOccupied("occupied", x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos && bds.ObjectCanMove(x - 1, y) && (bds.boardoccupied[x-1, y] == "monster" || bds.boardoccupied[x+1, y] == "monster"))
            {
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.left;
                board.GetComponent<Board>().SetOccupied("empty", x, y);
                x -= 1;
                bds.SetOccupied("occupied", x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos && bds.ObjectCanMove(x, y + 1) && (bds.boardoccupied[x, y + 1] == "monster" || bds.boardoccupied[x, y - 1] == "monster"))
            {
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.forward;
                bds.SetOccupied("empty", x, y);
                y += 1;
                bds.SetOccupied("occupied", x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos && bds.ObjectCanMove(x, y - 1) && (bds.boardoccupied[x, y + 1] == "monster" || bds.boardoccupied[x, y - 1] == "monster"))
            {
                Debug.Log("down");
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.back;
                bds.SetOccupied("empty", x, y);
                y -= 1;
                bds.SetOccupied("occupied", x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
