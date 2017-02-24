// using UnityEngine;
// using System.Collections;

// public class ObjectMove : MonoBehaviour {
//     public float speed = 2.0f;
//     public int height = 2;
//     private Vector3 pos;
//     private Transform tr;
//     public GameObject monster;
//     public int x;
//     public int y;
//     private Board board;
//     private GridMove mn;
//     bool shift;

//     // Use this for initialization
//     void Start()
//     {
//         pos = transform.position;
//         tr = transform;
//         board = Board.Instance;
//         mn = monster.GetComponent<GridMove>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             shift = true;
//         }
//         if (Input.GetKeyUp(KeyCode.LeftShift))
//         {
//             shift = false;
//         }
//         if (shift)
//         {
//             if (Input.GetKeyDown(KeyCode.D) && tr.position == pos && board.ObjectCanMove(x + 1, y) && mn.y == y && (mn.x == x - 1 || mn.x == x + 1))
//             {
//                 pos += Vector3.right;
//                 board.SetHeight(0, x, y);
//                 board.SetLight(true, x, y + 2);
//                 board.SetLight(true, x, y + 1);
//                 board.SetLight(true, x, y);

//                 x += 1;
//                 board.SetHeight(height, x, y);
//                 board.SetLight(false, x, y + 2);
//                 board.SetLight(false, x, y + 1);
//                 board.SetLight(false, x, y);

//             }
//             else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos && board.ObjectCanMove(x - 1, y) && mn.y == y && (mn.x == x - 1 || mn.x == x + 1))
//             {
//                 board.SetLight(true, x, y + 2);
//                 board.SetLight(true, x, y + 1);
//                 board.SetLight(true, x, y);

//                 pos += Vector3.left;
//                 board.SetHeight(0, x, y);
//                 x -= 1;
//                 board.SetHeight(height, x, y);
//                 board.SetLight(false, x, y + 2);
//                 board.SetLight(false, x, y + 1);
//                 board.SetLight(false, x, y);

//             }
//             else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos && board.ObjectCanMove(x, y + 1) && mn.x == x && (mn.y == y - 1 || mn.y == y + 1))
//             {
//                 board.SetLight(true, x, y + 2);
//                 board.SetLight(true, x, y + 1);
//                 board.SetLight(true, x, y);

//                 pos += Vector3.forward;
//                 board.SetHeight(0, x, y);
//                 y += 1;
//                 board.SetHeight(height, x, y);
//                 board.SetLight(false, x, y + 2);
//                 board.SetLight(false, x, y + 1);
//                 board.SetLight(false, x, y);

//             }
//             else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos && board.ObjectCanMove(x, y - 1) && mn.x == x && (mn.y == y - 1 || mn.y == y + 1))
//             {
//                 Debug.Log("down");
//                 board.SetLight(true, x, y + 2);
//                 board.SetLight(true, x, y + 1);
//                 board.SetLight(true, x, y);

//                 pos += Vector3.back;
//                 board.SetHeight(0, x, y);
//                 y -= 1;
//                 board.SetHeight(height, x, y);
//                 board.SetLight(false, x, y + 2);
//                 board.SetLight(false, x, y + 1);
//                 board.SetLight(false, x, y);

//             }
//         }
//         transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
//     }
// }
