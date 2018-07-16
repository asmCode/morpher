using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public Vector3[] Points { get; private set; }

    void Awake()
    {
        Vector3 center = Vector3.zero;

        Points = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Points[i] = transform.GetChild(i).transform.localPosition;
            center += Points[i];
        }

        center /= Points.Length;

        for (int i = 0; i < Points.Length; i++)
            Points[i] -= center;
    }
}
