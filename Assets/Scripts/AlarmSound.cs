using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _duration = 2f;
    private float _currentTime = 0f;
    private Predicate<float> _isMoreThanZero = (float volumeValue) => volumeValue > 0;
    private Predicate<float> _isLessThanOne = (float volumeValue) => volumeValue < 1;
    private float _startVolume;
    private float _endVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.Play();
        _startVolume = 0;
        _endVolume = 1;
    }

    public void SwichAlarm(int directionValue)
    {
        StartCoroutine(SetVolume(directionValue));
    }

    private IEnumerator SetVolume(int directionValue)
    {
        Predicate<float> predicate;

        if (directionValue == 1)
            predicate = _isLessThanOne;
        else
            predicate = _isMoreThanZero;

        while (predicate(_audioSource.volume))
        {
            _currentTime += Time.deltaTime / _duration * directionValue;
            _audioSource.volume = Mathf.Lerp(_startVolume, _endVolume, _currentTime);
            Debug.Log(_audioSource.volume);
            yield return new WaitForEndOfFrame();
        }
    }
}
