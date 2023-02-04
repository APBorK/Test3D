using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || _startPosition!=transform.position)
        {
            Move();
        }
    }
 
    void Move()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(myRay,out hitInfo))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z),Time.fixedDeltaTime * _speed);
        }
    }
    
    void StepСount()
    {
        
    }
}
