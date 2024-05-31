using UnityEngine;

public class LineCreator : MonoBehaviour
{
    private float _size = 0.2f;
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        GetComponent<LineRenderer>().endWidth = _size;
        GetComponent<LineRenderer>().startWidth _size;
        GetComponent<LineRenderer>().material = Resources.Load<Material>("Materials/LineMaterial");
    }

    public void DrawLines(Vector3[] points)
    {
        GetComponent<LineRenderer>().positionCount = points.Length;
        GetComponent<LineRenderer>().SetPositions(points);
    }
}
