using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;
    private Vector3 _newPosition;
    private float _distantion;
    private float _newDistanse;
    private float _allDistanse;
    private bool _moveGo = false;
    private bool _startCounter;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay,out hitInfo))
            {
                _moveGo = true;
                _newPosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                _distantion =  Vector3.Distance(_newPosition, transform.position);
                Debug.Log(_distantion);
            }
        }

        if (_moveGo)
        {
            Move();
            CounterMove();
            _startCounter = true;
        }
            

        if ( Vector3.Distance(_newPosition,  transform.position) <=1)
        {
            _moveGo = false;
            if (_startCounter)
            {
                EventSistem.SendMovePlayer(_allDistanse);
                _startCounter = false;
            }
            
        }
    }
    
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_newPosition.x, _newPosition.y, _newPosition.z),Time.fixedDeltaTime * _speed);
    }

    private void CounterMove()
    {
        _newDistanse = Mathf.Lerp(_allDistanse,_distantion,Time.fixedDeltaTime * _speed);
        _allDistanse = _newDistanse;
    }
    
}
