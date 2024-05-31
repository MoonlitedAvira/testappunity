using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    private float _lineWidth = 0.12f;
    private void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        GetComponent<LineRenderer>().startWidth = _lineWidth;
        GetComponent<LineRenderer>().endWidth = _lineWidth;
        GetComponent<LineRenderer>().material = Resources.Load("Materials/White") as Material;
    }
    public void DrawLines(List<Vector3> list)
    {
        GetComponent<LineRenderer>().positionCount = list.Count;
        GetComponent<LineRenderer>().SetPositions(list.ToArray());
    }
}
