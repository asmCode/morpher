using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputArea : MonoBehaviour
{
    public Transform m_cursor;
    public Transform m_cursor2;

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

        Vector3[] worldCorners = new Vector3[4];
        m_rectTransform.GetWorldCorners(worldCorners);
        m_bottomLeftCorner = worldCorners[0];
        m_topRightCorner = worldCorners[2];

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
        var position = Input.mousePosition;
        position.x = Mathf.Clamp(position.x, m_bottomLeftCorner.x, m_topRightCorner.x);
        position.y = Mathf.Clamp(position.y, m_bottomLeftCorner.y, m_topRightCorner.y);

        m_cursor.position = position;

        CursorPosition = position;
    }
}
