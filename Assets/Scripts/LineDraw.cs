using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LineDraw
{
    int a;
    int b;
    int x;
    public LineDraw(Vector2 baseLinePoint1, Vector2 baseLinePoint2, Vector2 point)
    {
        Vector2 slope = new();
        slope.x = baseLinePoint1.x - baseLinePoint2.x;
        slope.y = baseLinePoint1.y - baseLinePoint2.y;

        aboveLine(slope, point);
        
        

    }

    bool aboveLine(Vector2 slope, Vector2 point)
    {
        if (point.y < (slope.y / slope.x) * point.x)
        {

        }

        if(slope.y > ((slope.y / slope.x) * point.x)) {
            Debug.Log("Bigger");
        }

        return true;
    }

    

}
