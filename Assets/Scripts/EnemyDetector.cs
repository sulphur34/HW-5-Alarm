using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _trespassed;
    [SerializeField] private UnityEvent _escaped;
        
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
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
            StartCoroutine(FadeOnEscape());
        }
    }

    private IEnumerator FadeOnEscape()
    {
        while(_audioSource.volume > 0)
        {
            _escaped.Invoke();
            yield return new WaitForEndOfFrame();
        }
    }
}
