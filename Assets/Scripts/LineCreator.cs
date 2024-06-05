using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    [SerializeField] private float _lineWidth = 0.9f;
    [SerializeField] private Material _material;
    private LineRenderer _lineRenderer;
    private void Start()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;
        _lineRenderer.material = _material;
    }
    public void DrawLines(List<Vector3> list)
    {
        _lineRenderer.positionCount = list.Count;
        _lineRenderer.SetPositions(list.ToArray());
    }
}
