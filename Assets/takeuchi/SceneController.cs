using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        FadeController.StartFadeIn();
    }
    public void ChangeScene(string target)
    {
        SceneChange.LoadScene(target);
    }
}
