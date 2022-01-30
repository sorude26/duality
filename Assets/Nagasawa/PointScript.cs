using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    [SerializeField] float _alfa;
    MeshRenderer _r;
    [SerializeField] float _fadeSpeed;
    bool triggerEnter;
    bool triggerExit;

    void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerExit(Collider other)
    {
       
    }

    IEnumerator FadeIn(Color color)
    {
        MeshRenderer mr = _r;
        float clearScale = 255f;
        Color currentColor = color;
        while (clearScale > 0f)
        {
            clearScale -= _fadeSpeed * Time.deltaTime;
            if (clearScale <= 0f)
            {
                clearScale = 0f;
            }
            currentColor.a = clearScale;
            mr.material.color = currentColor;
            yield return null;
        }
        triggerEnter = false;
    }

    IEnumerator FadeOut(Color color)
    {
        MeshRenderer mr = _r;
        float clearScale = _alfa;
        Color currentColor = color;
        while (clearScale < _alfa)
        {
            clearScale += _fadeSpeed * Time.deltaTime;
            if (clearScale >= 1f)
            {
                clearScale = 1f;
            }
            currentColor.a = clearScale;
            mr.material.color = currentColor;
            yield return null;
        }
        triggerExit = false;
    }
}
