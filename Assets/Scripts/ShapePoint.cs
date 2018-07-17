using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePoint
{
    private Vector3 m_point;
    private Vector3 m_oppisiteCorner1;
    private Vector3 m_oppisiteCorner2;

    public ShapePoint(Vector3 point, Vector3 oppisiteCorner1, Vector3 oppisiteCorner2)
    {
        m_point = point;
        m_oppisiteCorner1 = oppisiteCorner1;
        m_oppisiteCorner2 = oppisiteCorner2;
    }

    public float GetWeight(Vector3 point)
    {
        if (Vector3.Distance(m_point, point) < Mathf.Epsilon)
            return 1.0f;

        var line1 = new Line(m_point, point);
        var line2 = new Line(m_oppisiteCorner1, m_oppisiteCorner2);

        Vector3 intersectionPoint = new Vector3();
        if (!Line.GetIntersection(line1, line2, ref intersectionPoint))
            return 0.0f;

        return 1.0f - Vector3.Distance(m_point, point) / Vector3.Distance(intersectionPoint, m_point);
    }
}
