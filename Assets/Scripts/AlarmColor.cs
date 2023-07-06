using UnityEngine;


public class AlarmColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;    
    [SerializeField] private Color _endColor;

    private Color _startColor = Color.white;
    private float _duration = 2f;
    private float _currentTime = 0f;
    
    public void ReduceColor()
    {
        if (_currentTime >= 0)
            _currentTime -= Time.deltaTime / _duration;
        else
            _currentTime = 0f;

        SwichColor(_currentTime);
    }
    public void AmplifyColor()
    {
        if (_currentTime < 1)
            _currentTime += Time.deltaTime / _duration;
        else
            _currentTime = 1;

        SwichColor(_currentTime);
    }

    private void SwichColor(float currentTime)
    {
        float lerpValue = Mathf.Lerp(0f, 1f, currentTime);
        Color newColor = Color.Lerp(_startColor, _endColor, lerpValue);
        _spriteRenderer.color = newColor;
    }
}
