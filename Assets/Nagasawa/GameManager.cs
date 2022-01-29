using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    [SerializeField] string _gameOverSceneName;

    void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    static public void GameOver()
    {
        SceneChange.LoadScene(Instance._gameOverSceneName);
    }
}
