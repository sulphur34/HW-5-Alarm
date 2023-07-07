using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _endVolume;

    private AudioSource _audioSource;
    private float _duration = 2f;
    private float _currentTime = 0f;
    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.Play();
    }
   
    public void SetVolume(int directionValue)
    {
        _currentTime += Time.deltaTime / _duration * directionValue;        
        _audioSource.volume = Mathf.Lerp(_startVolume, _endVolume, _currentTime);
    }    
}
