using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputArea : MonoBehaviour
{
    public Transform m_cursor;
    public Transform m_cursor2;
    public Transform m_cursor3;
    public Canvas canvas;

    private RectTransform m_rectTransform;
    private bool m_initialized;

    private Vector3 m_bottomLeftCorner;
    private Vector3 m_topRightCorner;

    public Vector3 CursorPosition
    {
        get; private set;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (m_initialized)
            return;

        m_rectTransform = GetComponent<RectTransform>();
        m_bottomLeftCorner = new Vector3(m_rectTransform.rect.xMin, m_rectTransform.rect.yMin);
        m_topRightCorner = new Vector3(m_rectTransform.rect.xMax, m_rectTransform.rect.yMax);

        m_initialized = true;
    }

    public Vector3 GetBottomLeftCorner()
    {
        Init();

        return m_bottomLeftCorner;
    }

    public Vector3 GetTopRightCorner()
    {
        Init();

        return m_topRightCorner;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_bottomLeftCorner = new Vector3(m_rectTransform.rect.xMin, m_rectTransform.rect.yMin);
        m_topRightCorner = new Vector3(m_rectTransform.rect.xMax, m_rectTransform.rect.yMax);

        // var position = Input.mousePosition;

        var mousePosition2d = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var position = new Vector2();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_rectTransform, mousePosition2d, Camera.main, out position);

        position.x = Mathf.Clamp(position.x, m_rectTransform.rect.xMin, m_rectTransform.rect.xMax);
        position.y = Mathf.Clamp(position.y, m_rectTransform.rect.yMin, m_rectTransform.rect.yMax);

        m_cursor.localPosition = position;

        CursorPosition = position;
    }
}
