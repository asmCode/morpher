using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public ShapeRenderer m_shapeRenderer;
    public Shape m_shapeRectangle;
    public Shape m_shapeCircle;
    public Shape m_shapeHex;
    public Shape m_shapeStar;

    public InputArea m_inputArea;
    public ShapePoint m_rectShapePoint;

    public float m_weightRect = 1.0f;
    public float m_weightCircle = 0.0f;
    public float m_weightHex = 0.0f;
    public float m_weightStar = 0.0f;

    private void Awake()
    {
    }

    void Start()
    {
        var bottomLeft = m_inputArea.GetBottomLeftCorner();
        var topRight = m_inputArea.GetTopRightCorner();
        var topLeft = new Vector3(bottomLeft.x, topRight.y, 0.0f);
        var bottomRight = new Vector3(topRight.x, bottomLeft.y, 0.0f);

        m_rectShapePoint = new ShapePoint(bottomLeft, topLeft, topRight);
    }

    void Update()
    {
        ShapeMorpher morpher = new ShapeMorpher();
        morpher.AddShape(m_shapeRectangle.Points, m_weightRect);
        morpher.AddShape(m_shapeCircle.Points, m_weightCircle);
        morpher.AddShape(m_shapeHex.Points, m_weightHex);
        morpher.AddShape(m_shapeStar.Points, m_weightStar);

        m_shapeRenderer.DrawShape(morpher.Points, 4.0f);

        m_weightRect = m_rectShapePoint.GetWeight(m_inputArea.CursorPosition);

        // m_inputArea.m_cursor2.position = m_inputArea.GetBottomLeftCorner() + (m_inputArea.CursorPosition - m_inputArea.GetBottomLeftCorner()).normalized * m_weightRect;
    }
}
