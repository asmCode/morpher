using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeRenderer : MonoBehaviour
{
    public GameObject m_linePrefab;
    public Canvas m_canvas;

    private void Awake()
    {
        for (int i = 0; i < 60; i++)
        {
            Instantiate(m_linePrefab, transform);
        }
    }

    public void DrawShape(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            var child = transform.GetChild(i);

            Vector3 direction = points[(i + 1) % points.Length] - points[i];

            child.localScale = new Vector3(1.0f / m_canvas.scaleFactor, direction.magnitude / m_canvas.scaleFactor, 1.0f);
            child.up = direction;
            child.localPosition = points[i];
        }
    }
}
