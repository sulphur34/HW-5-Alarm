using UnityEngine;

[RequireComponent(typeof(Animator))]

public class GragOhr : MonoBehaviour
{
    private const string MoveX = "moveX";
    private const string ShootRange = "ShootRange";
    private const string Dead = "Dead";

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _isDead;
    private int _moveXIndex;
    private int _shootRangeIndex;
    private int _deadIndex;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isDead = false;
        _moveXIndex = Animator.StringToHash(MoveX);
        _shootRangeIndex = Animator.StringToHash(ShootRange);
        _deadIndex = Animator.StringToHash(Dead);
    }

    // Update is called once per frame
    private void Update() 
    {
        float shootingRange = 2f;

        if (_isDead == false)
        {
            float distance = (_target.position - transform.position).magnitude;
            _animator.SetFloat(_shootRangeIndex, distance);

            if (distance > shootingRange)
                MoveTowardsTarget();
            else
                _animator.SetFloat(_moveXIndex, 0);   
        }        
    }

    private void MoveTowardsTarget()
    {
        var moveVector = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        _animator.SetFloat(_moveXIndex, Mathf.Abs(moveVector.x));
        transform.position = moveVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float bulletforce = 10f;
        float timeToDestroy = 3;
        collision.gameObject.GetComponent<Rigidbody>();
        Vector3 impactForce = collision.relativeVelocity;

        if (impactForce.magnitude > bulletforce && _isDead == false)
        {
            _animator.SetTrigger(_deadIndex);
            _isDead = true;
            Destroy(gameObject, timeToDestroy);
        }
    }
}
