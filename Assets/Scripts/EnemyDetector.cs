using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _trespassed;
    [SerializeField] private UnityEvent _escaped;       
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out GragOhr gragOhr))
        {
           _trespassed.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GragOhr gragOhr))
        {
            _escaped.Invoke();
        }
    }

    
}
