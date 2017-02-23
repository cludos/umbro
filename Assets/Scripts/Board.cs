using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

    //Array representing cell states on the board
    //0,0 represents the bottom left cell
    //true in boardlight represents light
    public bool[,] boardlight;
    //cells can be empty, occupied or rug
    public string[,] boardoccupied;
    public int boardx;
    public int boardy;
    void Start () {
        boardlight = new bool[boardx, boardy];
        boardoccupied = new string[boardx, boardy];
        for (int i = 0; i< boardx; i++)
        {
            for(int j = 0; j< boardy; j++)
            {
                boardlight[i, j] = true;
            }
        }
        for (int i = 0; i < boardx; i++)
        {
            for (int j = 0; j < boardy; j++)
            {
                boardoccupied[i, j] = "empty";
            }
        }
        boardoccupied[0, 1] = "occupied";
        boardoccupied[1, 1] = "occupied";

        boardoccupied[1, 2] = "monster";
        boardoccupied[2, 3] = "kid";
        for (int i = 0; i<2; i++)
        {
            for (int j = 1; j<4; j++)
            {
                boardlight[i, j] = false;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool MonsterCanMove(int x, int y)
    {
        return !boardlight[x, y] && boardoccupied[x, y] != "occupied";
    }

    public bool KidCanMove(int x, int y)
    {
        return boardoccupied[x, y] != "occupied";
    }

    public bool ObjectCanMove(int x, int y)
    {
        return boardoccupied[x, y] == "empty"||boardoccupied[x,y]=="monster";
    }

    public void SetLight(bool light, int x, int y)
    {
        boardlight[x, y] = light;
    }

    public void SetOccupied(string occupied, int x, int y)
    {
        boardoccupied[x, y] = occupied;
    }
    
}
