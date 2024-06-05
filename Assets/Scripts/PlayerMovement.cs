using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private bool _isMoving = false;
    private LineCreator _lineCreator;
    private PointCreator _pointCreator;
    private Counter _counter;
    private Vector3 _pointPos;
    private Vector3 _movePos;
    private List<Vector3> _moveQueue = new() { Vector3.zero };
    private float _speed = 5f;
    [SerializeField] private GameObject _sliderObject;
    private Slider _slider;
    private void Start()
    {
        _lineCreator = GetComponent<LineCreator>();
        _pointCreator = GetComponent<PointCreator>();
        _counter = GetComponent<Counter>();
        _slider = _sliderObject.GetComponent<Slider>();
    }
    private void Update()
    {
        _speed = _slider.value;
        if (Input.GetMouseButtonDown(0))
        {
            _pointPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (math.sqrt(math.pow(_pointPos.x, 2) + math.pow(_pointPos.y, 2)) < 50)
            {
                _moveQueue.Add(_pointPos);
                _lineCreator.DrawLines(_moveQueue);
                _pointCreator.CreatePoints(_moveQueue);
                _counter.UpdateCounter(_moveQueue.Count);

                //Debug.Log("Added to queue");
            }
        }

        if (_isMoving)
        {
            if ((Vector2)transform.position == (Vector2)_movePos)
            {
                _pointCreator.DestroyPoint(0);
                _moveQueue.RemoveAt(0);
                _counter.UpdateCounter(_moveQueue.Count);
                _lineCreator.DrawLines(_moveQueue);
                _isMoving = false;

                //Debug.Log("Stoped");
            }
            else
                transform.position = Vector2.MoveTowards((Vector2)transform.position, _movePos, _speed * Time.deltaTime);
        }
        else
        {
            if (_moveQueue.Count > 1)
            {
                _movePos = _moveQueue[1];
                _isMoving = true;

                //Debug.Log("Moving");
            }
        }
    }
}