using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputArea : MonoBehaviour
{
    public Transform m_cursor;

    private RectTransform m_rectTransform;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] worldCorners = new Vector3[4];
        m_rectTransform.GetWorldCorners(worldCorners);
        Vector3 bottomLeft = worldCorners[0];
        Vector3 topRight = worldCorners[2];

        var position = Input.mousePosition;
        position.x = Mathf.Clamp(position.x, bottomLeft.x, topRight.x);
        position.y = Mathf.Clamp(position.y, bottomLeft.y, topRight.y);

        m_cursor.position = position;
    }
}
