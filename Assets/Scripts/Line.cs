using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    public Vector3 PointA { get; set; }
    public Vector3 PointB { get; set; }

    public Line(Vector3 pointA, Vector3 pointB)
    {
        PointA = pointA;
        PointB = pointB;
    }

    public static bool GetIntersection(Line line1, Line line2, ref Vector3 intersectionPoint)
    {
        if (Vector3.Distance(line1.PointA, line1.PointB) <= Mathf.Epsilon ||
            Vector3.Distance(line2.PointA, line2.PointB) <= Mathf.Epsilon)
            return false;

        var s1 = line1.PointA;
        var d1 = (line1.PointB - line1.PointA).normalized;

        var s2 = line2.PointA;
        var d2 = (line2.PointB - line2.PointA).normalized;

        if (Vector3.Distance(d2, d1) <= Mathf.Epsilon)
            return false;

        float l1 = Vector3.Cross(line2.PointA - line1.PointA, d2).magnitude / Vector3.Cross(d1, d2).magnitude;

        intersectionPoint = s1 + d1 * l1;
        
        return true;
    }
}
