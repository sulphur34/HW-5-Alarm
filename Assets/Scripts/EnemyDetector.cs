using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _trespassed;
    [SerializeField] private UnityEvent _escaped;

    private bool _isEnemyInsideTrigger;

    private void Update()
    {
        if(_isEnemyInsideTrigger)
            _trespassed.Invoke();
        else
            _escaped.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out GragOhr gragOhr))
        {
           _isEnemyInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GragOhr gragOhr))
        {
            _isEnemyInsideTrigger = false;
        }
    }
}
