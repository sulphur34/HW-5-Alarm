using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _trespassed;
    [SerializeField] private UnityEvent _escaped;
        
    private AudioSource _audioSource;
    private Predicate<float> _isMoreThanZero = (float volumeValue ) => volumeValue > 0;
    private Predicate<float> _isLessThanOne = (float volumeValue) => volumeValue < 1;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out GragOhr gragOhr))
        {
            StartCoroutine(SwichAlarm(_trespassed, _isLessThanOne));           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GragOhr gragOhr))
        {            
            StartCoroutine(SwichAlarm(_escaped, _isMoreThanZero));
        }
    }

    private IEnumerator SwichAlarm(UnityEvent swiched, Predicate<float> predicate)
    {
        while(predicate(_audioSource.volume))
        {
            swiched.Invoke();
            Debug.Log(_audioSource.volume);
            yield return new WaitForEndOfFrame();
        }
    }
}
