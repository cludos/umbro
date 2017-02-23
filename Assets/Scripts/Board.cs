using UnityEngine;
using System.Collections;

public struct Cell {
    public bool blocksObjects;
    public bool light;
    public int height;
}

public class Board : MonoBehaviour {

    public Cell[,] board;
    public int boardx;
    public int boardy;
    void Start () {
        board = new Cell[boardx, boardy];
        for (int i = 0; i< boardx; i++)
        {
            for(int j = 0; j< boardy; j++)
            {
                board[i, j].blocksObjects = false;
                board[i, j].light = true;
                board[i, j].height = 0;
            }
        }

        board[0, 1].height = 2;
        board[1, 1].height = 2;

        // boardoccupied[1, 2] = "monster";
        // boardoccupied[2, 3] = "kid";
        for (int i = 0; i<2; i++)
        {
            for (int j = 1; j<4; j++)
            {
                board[i, j].light = false;
            }
        }

    }

    // Update is called once per frame
    void Update () {

    }

    public bool MonsterCanMove(int x, int y)
    {
        return !board[x, y].light && board[x, y].height == 0;
    }

    public bool KidCanMove(int x, int y)
    {
        return board[x, y].height == 0;
    }

    public bool ObjectCanMove(int x, int y)
    {
        return board[x, y].height == 0 && !board[x, y].blocksObjects;
    }

    public void SetLight(bool light, int x, int y)
    {
        board[x, y].light = light;
    }

    public void SetHeight(int height, int x, int y)
    {
        board[x, y].height = height;
    }

    public void SetBlocking(bool blocking, int x, int y)
    {
        board [x, y].blocksObjects = blocking;
    }
}
