﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Cell {
    public bool light;
    public List<Entity> entities;
}

public class Entity : MonoBehaviour {
    public int x, y;
    public int height = 0;
    public bool blocksPlayers = false;
    public bool blocksBlocks = false;
    public Board board;

    public Entity(Board board, int x, int y) {
        this.board = board;
        this.x = x;
        this.y = y;
        board.board[x, y].entities.Add(this);
    }
}

public class Rug : Entity {
    public Rug(Board board, int x, int y) : base(board, x, y) {
        blocksBlocks = true;
    }
}

public class Block : Entity {
    public Block(Board board, int x, int y, int height) : base(board, x, y) {
        this.height = height;
    }
}

public class Moveable : Entity {
    public Moveable(Board board, int x, int y) : base(board, x, y) {
        blocksPlayers = true;
        blocksBlocks = true;
    }

    public bool CanMove(int nx, int ny) {
        return board.InRange(nx, ny);
    }

    public bool Move(int nx, int ny) {
        if (!CanMove(nx, ny)) return false;
        board.board[x,y].entities.Remove(this);
        x = nx;
        y = ny;
        board.board[x,y].entities.Add(this);
        return true;
    }
}

public class Kid : Moveable {
    public Kid(Board board, int x, int y) : base(board, x, y) {}

    public new bool CanMove(int nx, int ny) {
        return base.CanMove(nx, ny) && !board.BlocksPlayers(nx, ny);
    }
}

public class Monster : Moveable {
    public Monster(Board board, int x, int y) : base(board, x, y) {}

    public new bool CanMove(int nx, int ny) {
        return base.CanMove(nx, ny) && !board.BlocksPlayers(nx, ny) && !board.board[nx,ny].light;
    }
}

public class Board : MonoBehaviour {
    public Cell[,] board;
    public int width;
    public int height;
    public Monster monster;
    public Kid kid;

    /// <summary>
    /// Singleton
    /// </summary>
    public static Board Instance;

    void Awake () {
        // Register the singleton
        if (Instance != null) {
            Debug.LogError("Multiple instances of Board!");
        }
        Instance = this;
    }


    void Start () {
        for (int i = 0; i< width; i++) {
            for(int j = 0; j< height; j++) {
                board[i, j].light = true;
                board[i, j].entities = new List<Entity>();
            }
        }

        new Block(this, 0, 1, 2);
        new Block(this, 1, 1, 2);

        monster = new Monster(this, 1, 2);
        kid = new Kid (this, 2, 3);
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

    public bool BlocksPlayers(int x, int y) {
        foreach (Entity e in board[x,y].entities) {
            if (e.blocksPlayers) {
                return true;
            }
        }
        return false;
    }

    public bool BlocksBlocks(int x, int y) {
        foreach (Entity e in board[x,y].entities) {
            if (e.blocksBlocks) {
                return true;
            }
        }
        return false;
    }

    public bool GetLight(int x, int y) {
        if (!InRange (x, y))
            return false;
        return board[x,y].light;
    }

    public void SetLight(bool light, int x, int y) {
        if (!InRange(x,y)) return;
        board[x,y].light = light;
    }

    public int GetHeight(int x, int y) {
        if (!InRange(x,y)) return 0;
        int maxHeight = 0;
        foreach (Entity e in board[x,y].entities) {
            if (e.height > maxHeight) {
                maxHeight = e.height;
            }
        }
        return maxHeight;
    }

    public bool InRange(int x, int y) {
        return 0 <= x && width > x && 0 <= y && height > y;
    }
}
