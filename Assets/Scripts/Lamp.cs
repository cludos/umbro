using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampRay : Ray
{
    private Vector2 pos;
    private Vector2[] dirs = {Vector2.zero, Vector2.right, Vector2.one, Vector2.up,
                                Vector2.up + Vector2.left, Vector2.left, Vector2.left +
                                Vector2.down, Vector2.down, Vector2.down +  Vector2.right};
    private int emmitedCount = 0;
    private Vector2 next;


    public lampRay(Vector2 pos)
    {
        this.pos = pos;
    }

    public bool hasNextLight()
    {
        getNext();
        return emmitedCount < dirs.Length && next.x >= 0; 
    }

    public Vector2 nextLight()
    {
        Vector2 prev = next;
        next = new Vector2(-1, -1);
        return prev;
    }

    private void getNext()
    {
        Vector2 dir = dirs[emmitedCount];
        Vector2 rayLoc = new Vector2(pos.x, pos.y) + dir;
        int height = Board.Instance.GetHeight((int)rayLoc.x, (int)rayLoc.y);
        while (height > 0)
        {
            dir = dirs[++emmitedCount];
            rayLoc = new Vector2(pos.x, pos.y) + dir;
            height = Board.Instance.GetHeight((int)rayLoc.x, (int)rayLoc.y);
            if (emmitedCount >= dirs.Length)
            {
                next = new Vector2(-1,-1);
                return;
            }
        }
        next = rayLoc;
    }
}


public class Lamp : LightSource
{
    public new Ray getPath()
    {
        return new lampRay(transform.position);
    }
}
