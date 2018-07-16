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
        if (Vector3.Distance(point, m_point) <= Mathf.Epsilon)
            return 1.0f;

        var s1 = m_point;
        var d1 = (point - m_point).normalized;

        var s2 = m_oppisiteCorner1;
        var d2 = (m_oppisiteCorner2 - m_oppisiteCorner1).normalized;

        if (Vector3.Distance(d2, d1) <= Mathf.Epsilon)
            return -1;

        float l1 = Vector3.Cross(m_oppisiteCorner1 - m_point, d2).magnitude / Vector3.Cross(d1, d2).magnitude;

        var maxDistancePoint = s1 + d1 * l1;
        
        return 1.0f - Vector3.Distance(m_point, point) / Vector3.Distance(maxDistancePoint, m_point);
    }
}
