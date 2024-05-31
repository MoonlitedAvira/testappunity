using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _pointPos;
    private Vector3 _movePos;
    private readonly List<Vector3> _moveQueue = new() { Vector3.zero };
    private float _speed = 5f;
    [SerializeField] private GameObject _slider;

    private void Update()
    {
        _speed = _slider.GetComponent<Slider>().value;
        if (Input.GetMouseButtonDown(0))
        {
            _pointPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (math.sqrt(math.pow(_pointPos.x, 2) + math.pow(_pointPos.y, 2)) < 12)
            {
                _moveQueue.Add(_pointPos);
                GetComponent<LineCreator>().DrawLines(_moveQueue);
                GetComponent<PointCreator>().CreatePoints(_moveQueue);
                GetComponent<Counter>().UpdateCounter(_moveQueue.Count);

                //Debug.Log("Added to queue");
            }
        }

        if (_isMoving)
        {
            if ((Vector2)transform.position == (Vector2)_movePos)
            {
                GetComponent<PointCreator>().DestroyPoint(0);
                _moveQueue.RemoveAt(0);
                GetComponent<Counter>().UpdateCounter(_moveQueue.Count);
                GetComponent<LineCreator>().DrawLines(_moveQueue);
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