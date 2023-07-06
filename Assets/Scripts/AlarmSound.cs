using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _duration = 2f;
    private float _currentTime = 0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.Play();
    }
   
    public void AmplifyVolume()
    {
        if (_currentTime < 1)
            _currentTime += Time.deltaTime / _duration;

        _audioSource.volume = Mathf.Lerp(0f, 1f, _currentTime);
    }
    public void ReduceVolume()
    {
        if(_currentTime >= 0)
            _currentTime -= Time.deltaTime / _duration;

        _audioSource.volume = Mathf.Lerp(0f, 1f, _currentTime);
    }
}
