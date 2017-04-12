using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PathObject
{
    public PathObject(Vector2[] pos)
    {
        Position = pos;
    }
    public Vector2[] Position;
}
