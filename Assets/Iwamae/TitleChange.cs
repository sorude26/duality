using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChange : MonoBehaviour
{
    [SerializeField]
    string _target = "StoryBoardScene";
    bool _change = false;
    void Start()
    {
        FadeController.StartFadeIn();
    }
    public void Change()
    {
        if (_change)
        {
            return;
        }
        _change = true;
        SceneChange.LoadScene(_target);
    }
}
