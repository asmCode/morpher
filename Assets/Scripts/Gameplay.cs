using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public ShapeRenderer m_shapeRenderer;
    public Transform m_shape;

    void Start()
    {
        Vector3[] points = new Vector3[m_shape.childCount];
        for (int i = 0; i < m_shape.childCount; i++)
            points[i] = m_shape.GetChild(i).transform.position;

        m_shapeRenderer.DrawShape(points);
    }
}
