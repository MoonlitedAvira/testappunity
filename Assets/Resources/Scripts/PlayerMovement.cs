using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _pointPos, _movePos;
    private readonly List<Vector3> _moveQueue = new() { Vector3.zero };
    [SerializeField] private float _speed = 5f;
    private void Start()
    {
        gameObject.AddComponent<LineCreator>();
        gameObject.AddComponent<PointCreator>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pointPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (math.sqrt(math.pow(_pointPos.x, 2) + math.pow(_pointPos.y, 2)) < 5)
            {
                _moveQueue.Add(_pointPos);
                GetComponent<LineCreator>().DrawLines(_moveQueue.ToArray());
                GetComponent<PointCreator>().CreatePoint(_pointPos);
            }
        }

        if (_isMoving)
        {
            if ((Vector2)transform.position == (Vector2)_movePos)
            {
                GetComponent<PointCreator>().RemovePoint(0);
                _moveQueue.RemoveAt(0);
                GetComponent<LineCreator>().DrawLines(_moveQueue.ToArray());
                _isMoving = false;

                //Debug.Log("Stoped");
            }
            else
            {
                transform.position = Vector2.MoveTowards((Vector2)transform.position, _movePos, _speed * Time.deltaTime);
            }
        }
        else
        {
            if (_moveQueue.Count > 1)
            {
                _movePos = _moveQueue[1];
                _isMoving = true;

                //Debug.Log("Run to point");
            }
        }
    }
}