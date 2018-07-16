using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public ShapeRenderer m_shapeRenderer;
    public Shape m_shapeCircle;
    public Shape m_shapeStar;

    public float m_starOrCircle = 0.0f;

    void Start()
    {
        // m_shapeRenderer.DrawShape(m_shape.Points, 4.0f);
    }

    void Update()
    {
        ShapeMorpher morpher = new ShapeMorpher();
        morpher.AddShape(m_shapeCircle.Points, m_starOrCircle);
        morpher.AddShape(m_shapeStar.Points, 1.0f - m_starOrCircle);

        m_shapeRenderer.DrawShape(morpher.Points, 4.0f);
    }
}
