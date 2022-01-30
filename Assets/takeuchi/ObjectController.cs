using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    GameObject _object = default;
    [SerializeField]
    bool _night = false;
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
        if (_night)
        {
            _object.SetActive(false);
            _night = false;
        }
        else
        {
            _object.SetActive(true);
            _night = true;
        }
    }
}
