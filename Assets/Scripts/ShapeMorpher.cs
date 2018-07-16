using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMorpher
{
    public Vector3[] Points { get; private set; }

    public void AddShape(Vector3[] points, float weight)
    {
        if (Points == null)
            Points = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
            Points[i] += points[i] * weight;
    }
}
