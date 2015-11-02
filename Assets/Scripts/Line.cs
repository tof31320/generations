using UnityEngine;
using System;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public Vector3 start = Vector3.zero;

    public Vector3 end = Vector3.zero;

    public Line lineStart = null;

    public Line lineEnd = null;   

    public float Size()
    {
        return Vector3.Distance(start, end);
    }
}

