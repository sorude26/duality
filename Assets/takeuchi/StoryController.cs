using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    [SerializeField]
    string _targetScene = "Game";
    [SerializeField]
    GameObject[] _images = default;
    int _viewCount = 0;
    bool _next = false;
    void Start()
    {
        for (int i = 1; i < _images.Length; i++)
        {
            _images[i].SetActive(false);
        }
        FadeController.StartFadeIn();
    }
    public void Next()
    {
        if (_next)
        {
            return;
        }
        if (_viewCount + 1 >= _images.Length)
        {
            Skip();
            return;
        }
        _next = true;
        FadeController.StartFadeOutIn(ChangeImage, () => { _next = false; });
    }
    public void Skip()
    {
        if (_next)
        {
            return;
        }
        _next = true;
        SceneChange.LoadScene(_targetScene);
    }
    void ChangeImage()
    {
        _images[_viewCount].SetActive(false);
        _viewCount++;
        _images[_viewCount].SetActive(true);
    }
}
