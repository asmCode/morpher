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
    public ShapePoint m_circleShapePoint;
    public ShapePoint m_hexShapePoint;
    public ShapePoint m_starShapePoint;

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

        var pointAOppositeEdges = new List<Line>() { new Line(topLeft, topRight), new Line(topRight, bottomRight) };
        m_rectShapePoint = new ShapePoint(bottomLeft, pointAOppositeEdges);

        var pointBOppositeEdges = new List<Line>() { new Line(bottomLeft, bottomRight), new Line(bottomRight, topRight) };
        m_circleShapePoint = new ShapePoint(topLeft, pointBOppositeEdges);

        var pointCOppositeEdges = new List<Line>() { new Line(bottomRight, bottomLeft), new Line(bottomLeft, topLeft) };
        m_hexShapePoint = new ShapePoint(topRight, pointCOppositeEdges);

        var pointDOppositeEdges = new List<Line>() { new Line(bottomLeft, topLeft), new Line(topLeft, topRight) };
        m_starShapePoint = new ShapePoint(bottomRight, pointDOppositeEdges);
    }

    void Update()
    {
        m_weightRect = m_rectShapePoint.GetWeight(m_inputArea.CursorPosition);
        m_weightCircle = m_circleShapePoint.GetWeight(m_inputArea.CursorPosition);
        m_weightHex = m_hexShapePoint.GetWeight(m_inputArea.CursorPosition);
        m_weightStar = m_starShapePoint.GetWeight(m_inputArea.CursorPosition);

        float norm = 1.0f / (m_weightRect + m_weightCircle + m_weightHex + m_weightStar);
        m_weightRect *= norm;
        m_weightCircle *= norm;
        m_weightHex *= norm;
        m_weightStar *= norm;

        ShapeMorpher morpher = new ShapeMorpher();
        morpher.AddShape(m_shapeRectangle.Points, m_weightRect);
        morpher.AddShape(m_shapeCircle.Points, m_weightCircle);
        morpher.AddShape(m_shapeHex.Points, m_weightHex);
        morpher.AddShape(m_shapeStar.Points, m_weightStar);

        m_shapeRenderer.DrawShape(morpher.Points, 4.0f);


        // m_inputArea.m_cursor2.position = m_inputArea.GetBottomLeftCorner() + (m_inputArea.CursorPosition - m_inputArea.GetBottomLeftCorner()).normalized * m_weightRect;
    }
}
