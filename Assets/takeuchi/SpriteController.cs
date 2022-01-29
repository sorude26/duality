using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] _sprites = default;
    [SerializeField]
    Color _shadowColor = default;
    [SerializeField]
    float _changeSpeed = 0.1f;
    [SerializeField]
    bool _night = false;
    bool _change = false;
    private void OnEnable()
    {
        EventManager.OnChangeTimeZone += ChangeTimeZone;
    }
    private void OnDisable()
    {
        EventManager.OnChangeTimeZone -= ChangeTimeZone;
    }
    public void ChangeTimeZone()
    {
        if (_change)
        {
            return;
        }
        _change = true;
        if (_night)
        {
            StartCoroutine(ChangeIntensityUp());
        }
        else
        {
            StartCoroutine(ChangeIntensityDown());
        }
    }
    IEnumerator ChangeIntensityUp()
    {
        Color current = _sprites[0].color;
        float timer = 0;
        while (timer < 1)
        {
            timer += _changeSpeed * Time.deltaTime;
            current = Color.Lerp(current, Color.white, timer);
            SetColor(current);
            yield return null;
        }
        SetColor(Color.white);
        _change = false;
        _night = false;
    }
    IEnumerator ChangeIntensityDown()
    {
        Color current = _sprites[0].color;
        float timer = 0;
        while (timer < 1)
        {
            timer += _changeSpeed * Time.deltaTime;
            current = Color.Lerp(current, _shadowColor, timer);
            SetColor(current);
            yield return null;
        }
        SetColor(_shadowColor);
        _change = false;
        _night = true;
    }
    void SetColor(Color color)
    {
        foreach (var sprite in _sprites)
        {
            sprite.color = color;
        }
    }
}
