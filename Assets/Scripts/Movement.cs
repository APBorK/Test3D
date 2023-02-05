using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _newPosition;
    private float _distantion;
    private float _newDistanse;
    private float _allDistanse;
    private bool _move = false;
    private bool _startCounter;
    private Queue<Vector3> _queuePosition = new Queue<Vector3>();
    private LineRenderer _path;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay,out hitInfo))
            {
                _queuePosition.Enqueue(new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z));
                if (hitInfo.collider.tag == "Player")
                {
                    _queuePosition.Clear();
                    transform.position = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_queuePosition.Count != 0)
            {
                _move = true;
                _newPosition = _queuePosition.Dequeue();
                _distantion =  Vector3.Distance(_newPosition, transform.position);
            }
        }

        if (_move)
        {
            Move();
            CounterMove();
            _startCounter = true;
        }
            

        if ( Vector3.Distance(_newPosition,  transform.position) <=1)
        {
            if (_queuePosition.Count != 0)
            {
                _newPosition = _queuePosition.Dequeue();
                _distantion =  Vector3.Distance(_newPosition, transform.position);
                _move = true;
            }
            else
            {
                _move = false;
            }
            if (_startCounter)
            {
                EventSistem.SendMovePlayer(_allDistanse);
                _startCounter = false;
            }
        }
    }
    
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_newPosition.x, _newPosition.y, _newPosition.z),Time.deltaTime * _speed);
    }

    private void CounterMove()
    {
        _newDistanse = Mathf.Lerp(_allDistanse,_distantion,Time.fixedDeltaTime * _speed);
        _allDistanse = _newDistanse;
    }
    
}
