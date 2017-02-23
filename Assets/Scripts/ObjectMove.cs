using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {
    public float speed = 2.0f;
    public int height = 2;
    private Vector3 pos;
    private Transform tr;
    public GameObject board;
    public GameObject monster;
    public int x;
    public int y;
    private Board bds;
    private GridMove mn;
    bool shift;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        tr = transform;
        bds = board.GetComponent<Board>();
        mn = monster.GetComponent<GridMove>();
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
            if (Input.GetKeyDown(KeyCode.D) && tr.position == pos && bds.ObjectCanMove(x + 1, y) && mn.y == y && (mn.x == x - 1 || mn.x == x + 1))
            {
                pos += Vector3.right;
                bds.SetHeight(0, x, y);
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                x += 1;
                bds.SetHeight(height, x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos && bds.ObjectCanMove(x - 1, y) && mn.y == y && (mn.x == x - 1 || mn.x == x + 1))
            {
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.left;
                bds.SetHeight(0, x, y);
                x -= 1;
                bds.SetHeight(height, x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos && bds.ObjectCanMove(x, y + 1) && mn.x == x && (mn.y == y - 1 || mn.y == y + 1))
            {
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.forward;
                bds.SetHeight(0, x, y);
                y += 1;
                bds.SetHeight(height, x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
            else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos && bds.ObjectCanMove(x, y - 1) && mn.x == x && (mn.y == y - 1 || mn.y == y + 1))
            {
                Debug.Log("down");
                bds.SetLight(true, x, y + 2);
                bds.SetLight(true, x, y + 1);
                bds.SetLight(true, x, y);

                pos += Vector3.back;
                bds.SetHeight(0, x, y);
                y -= 1;
                bds.SetHeight(height, x, y);
                bds.SetLight(false, x, y + 2);
                bds.SetLight(false, x, y + 1);
                bds.SetLight(false, x, y);

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
