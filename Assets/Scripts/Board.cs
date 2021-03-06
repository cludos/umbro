﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public struct Cell
{
    public bool light;
    public List<Entity> entities;
}

public class Entity
{
    public int x, y;
    public int height = 0;
    public bool blocksPlayers = false;
    public bool blocksBlocks = false;
    public Board board;

    public Entity(Board board, int x, int y)
    {
        this.board = board;
        this.x = x;
        this.y = y;
        board.board[x, y].entities.Add(this);
    }
}

public class Exit : Entity
{
    public Exit(Board board, int x, int y) : base(board, x, y) {
        blocksBlocks = true;
    }
}

public class Rug : Entity
{
    public Rug(Board board, int x, int y) : base(board, x, y)
    {
        blocksBlocks = true;
    }
}

public class Switch : Entity
{
    private List<LightSource> lights;

    public Switch(Board board, int x, int y, List<LightSource> lights) : base(board, x, y)
    {
        blocksBlocks = true;
        this.lights = lights;
    }

    public void toggleLights()
    {
        foreach (LightSource ls in lights)
        {
            ls.setPower(!ls.isOn);
        }
        Board.Instance.triggerLightSources();
    }
}

public class Moveable : Entity
{
    public Moveable(Board board, int x, int y) : base(board, x, y)
    {
        blocksPlayers = true;
        blocksBlocks = true;
    }

    public virtual bool CanMove(int nx, int ny)
    {
        return board.InRange(nx, ny);
    }

    public virtual bool Move(int nx, int ny)
    {
        if (!CanMove(nx, ny)) return false;
        board.board[x, y].entities.Remove(this);
        x = nx;
        y = ny;
        board.board[x, y].entities.Add(this);
        return true;
    }
}

public class Block : Moveable
{
    public Block(Board board, int x, int y, int height) : base(board, x, y)
    {
        this.height = height;
        blocksPlayers = true;
    }

    public override bool CanMove(int nx, int ny)
    {
        return base.CanMove(nx, ny) && !board.BlocksBlocks(nx, ny);
    }

    public override bool Move(int nx, int ny)
    {

        bool succ = base.Move(nx, ny);
        board.triggerLightSources();
        return succ;
    }

}


public class Kid : Moveable
{
    public Kid(Board board, int x, int y) : base(board, x, y) { }

    public override bool CanMove(int nx, int ny)
    {
        return base.CanMove(nx, ny) && !board.BlocksPlayers(nx, ny);
    }
}

public class Monster : Moveable
{
    public Monster(Board board, int x, int y) : base(board, x, y) {
        blocksBlocks = false;
    }

    public override bool CanMove(int nx, int ny)
    {
        return base.CanMove(nx, ny) && !board.BlocksPlayers(nx, ny) && !board.board[nx, ny].light;
    }

    public override bool Move(int nx, int ny)
    {
        int dirx = nx - x;
        int diry = ny - y;
        bool shiftDown = Input.GetKey(KeyCode.LeftShift);

        Block b = null;
        bool blockMoveSucc = true;
        int oldBX = 0;
        int oldBY = 0;
        if (shiftDown && board.GetHeight(nx, ny) > 0)
        {
            oldBX = nx;
            oldBY = ny;
            b = (Block)board.board[nx, ny].entities[0];
            blockMoveSucc = b.Move(nx + dirx, ny + diry);
        }
        else if (shiftDown && board.GetHeight(x - dirx, y - diry) > 0)
        {
            oldBX = x - dirx;
            oldBY = y - diry;
            b = (Block)board.board[x - dirx, y - diry].entities[0];
            blockMoveSucc = b.Move(x, y);
        }

        if (blockMoveSucc && base.Move(nx, ny))
        {
            if (board.IsExit(nx, ny))
            {
                board.CompleteLevel();
            }
            return true;
        }
        if (blockMoveSucc && b != null)
        {
            b.Move(oldBX, oldBY);
        }

        return false;
    }
}

public class Board : MonoBehaviour
{
    public int nextScene = 2;
    //public GameObject[] tiles;
    public Cell[,] board;
    public int width;
    public int height;
    public Monster monster;
    public Kid kid;
    private List<LightSource> lights;

    /// <summary>
    /// Singleton
    /// </summary>
    public static Board Instance;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Board!");
        }
        Instance = this;
    }


    void Start()
    {
        board = new Cell[width, height];
        lights = new List<LightSource>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                board[i, j].light = false;
                board[i, j].entities = new List<Entity>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool BlocksPlayers(int x, int y)
    {
        if (!InRange(x, y)) return true;
        foreach (Entity e in board[x, y].entities)
        {
            if (e.blocksPlayers)
            {
                return true;
            }
        }
        return false;
    }

    public bool BlocksBlocks(int x, int y)
    {
        if (!InRange(x, y)) return true;
        foreach (Entity e in board[x, y].entities)
        {
            if (e.blocksBlocks)
            {
                return true;
            }
        }
        return false;
    }

    public bool GetLight(int x, int y)
    {
        if (!InRange(x, y))
            return false;
        return board[x, y].light;
    }

    public void SetLight(bool light, int x, int y)
    {
        if (!InRange(x, y)) return;
        //tiles[x * height + y].GetComponent<Tile>().SetLight(light);
        board[x, y].light = light;
    }

    public int GetHeight(int x, int y)
    {
        if (!InRange(x, y)) return 0;
        int maxHeight = 0;
        foreach (Entity e in board[x, y].entities)
        {
            if (e.height > maxHeight)
            {
                maxHeight = e.height;
            }
        }
        return maxHeight;
    }

    public bool IsExit(int x, int y)
    {
        foreach (Entity e in board[x, y].entities)
        {
            if (e is Exit)
            {
                return true;
            }
        }
        return false;
    }

    public void AddLightSource(LightSource ls)
    {
        lights.Add(ls);
        triggerLightSources();
    }

    public void triggerLightSources()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                SetLight(false, i, j);
            }
        }

        foreach (LightSource ls in lights)
        {
            ls.UpdateLights();
        }
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetString("endtext", "You did it! Woo!");
        SceneManager.LoadScene(nextScene);
    }

    public void LoseLevel()
    {
        PlayerPrefs.SetString("endtext", "You failed. RIP Umbro.");
        SceneManager.LoadScene(nextScene);
    }

    public bool InRange(int x, int y)
    {
        return 0 <= x && width > x && 0 <= y && height > y;
    }
}
