using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Aligner : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [MenuItem("Align/Between")]
    public static void AlignBetween()
    {
        var count = Selection.gameObjects.Length;

        if (count < 3)
            return;

        var selected = new GameObject[count];
        System.Array.Copy(Selection.gameObjects, selected, count);

        System.Array.Sort(selected, (a, b) => { return a.name.CompareTo(b.name); });

        var startPosition = selected[0].transform.position;
        var endPosition = selected[count - 1].transform.position;

        var direction = endPosition - startPosition;
        var length = direction.magnitude;
        float step = length / (count - 1);
        direction.Normalize();

        for (int i = 0; i < count; i++)
        {
            selected[i].transform.position = startPosition + direction * step * i;
        }
    }

    [MenuItem("Align/Rename")]
    public static void Rename()
    {
        var count = Selection.gameObjects.Length;

        if (count == 0)
            return;

        var selected = new GameObject[count];
        System.Array.Copy(Selection.gameObjects, selected, count);

        System.Array.Sort(selected, (a, b) => { return a.name.CompareTo(b.name); });

        var startPosition = selected[0].transform.position;
        var endPosition = selected[count - 1].transform.position;

        var direction = endPosition - startPosition;
        var length = direction.magnitude;
        float step = length / (count - 1);
        direction.Normalize();

        for (int i = 0; i < count; i++)
        {
            selected[i].name = string.Format("point_{0:D2}", i);
        }
    }
}
