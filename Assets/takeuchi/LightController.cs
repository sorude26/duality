using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    Light _light = default;
    [SerializeField]
    float _daytimeIntensity = 1f;
    [SerializeField]
    float _changeSpeed = 1f;
    [SerializeField]
    bool _night = false;
    bool _change = false;
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
        float current = _light.intensity;
        while (current < _daytimeIntensity)
        {
            current += _changeSpeed * Time.deltaTime;
            _light.intensity = current;
            yield return null;
        }
        _light.intensity = _daytimeIntensity;
        _change = false;
        _night = false;
    }
    IEnumerator ChangeIntensityDown()
    {
        float current = _light.intensity;
        while (current > 0)
        {
            current -= _changeSpeed * Time.deltaTime;
            _light.intensity = current;
            yield return null;
        }
        _light.intensity = 0;
        _change = false;
        _night = true;
    }
}
