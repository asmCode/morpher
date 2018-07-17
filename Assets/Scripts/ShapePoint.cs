using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePoint
{
    private Vector3 m_point;

    private List<Line> m_oppositeEdges = new List<Line>();

    public ShapePoint(Vector3 point, List<Line> oppositeEdges)
    {
        m_point = point;
        m_oppositeEdges = oppositeEdges;
    }

    public float GetWeight(Vector3 point)
    {
        if (Vector3.Distance(m_point, point) < Mathf.Epsilon)
            return 1.0f;

        var line1 = new Line(m_point, point);
        var closestIntersectionPoint = new Vector3(9999, 9999, 9999);

        foreach (var line2 in m_oppositeEdges)
        {
            Vector3 intersectionPoint = new Vector3();
            if (!Line.GetIntersection(line1, line2, ref intersectionPoint))
                continue;

            if (Vector3.Distance(point, intersectionPoint) < Vector3.Distance(point, closestIntersectionPoint))
                closestIntersectionPoint = intersectionPoint;
        }

        return 1.0f - Vector3.Distance(m_point, point) / Vector3.Distance(closestIntersectionPoint, m_point);
    }
}
