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


    public lampRay(Vector2 pos)
    {
        this.pos = pos;
    }

    public bool hasNextLight()
    {
        return emmitedCount < dirs.Length; 
    }

    public Vector2 nextLight()
    {
        Vector2 dir = dirs[emmitedCount++];
        Vector2 rayLoc = new Vector2(pos.x, pos.y) + dir;
        return rayLoc;
    }

}


public class Lamp : LightSource
{
    public override Ray getPath()
    {
        return new lampRay(new Vector2(x, y));
    }

    public override void setPower(bool power)
    {
        base.setPower(power);
        Light light = GetComponent<Light>();
        light.enabled = power;
    }

}
