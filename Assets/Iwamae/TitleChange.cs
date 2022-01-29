using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChange : MonoBehaviour
{
    public void Change()
    {
        SceneChange.LoadScene("Game");
    }
}
