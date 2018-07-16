using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public ShapeRenderer m_shapeRenderer;
    public Shape m_shape;

    void Start()
    {
        m_shapeRenderer.DrawShape(m_shape.Points);
    }
}
