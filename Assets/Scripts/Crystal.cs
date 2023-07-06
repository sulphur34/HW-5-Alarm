
using UnityEngine;
using UnityEngine.Events;

public class Crystal : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _currentDestinationPosition;   

    private void Start()
    {
        float floatingDistance = -0.3f;
        _startPosition = new Vector3(0f,0f,0f) + transform.position;
        _endPosition = new Vector3(0f,floatingDistance, 0f) + transform.position;
    }

    private void Update()
    {
        if (transform.position == _startPosition)
            _currentDestinationPosition = _endPosition;
        else if (transform.position == _endPosition)
            _currentDestinationPosition = _startPosition;

        MoveTowardsTarget(_currentDestinationPosition);
    }

    private void MoveTowardsTarget(Vector3 destinationPosition)
    {
        var moveVector = Vector2.MoveTowards(transform.position, destinationPosition, _speed * Time.deltaTime);
        transform.position = moveVector;
    }
}
