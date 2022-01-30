using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    [SerializeField] string _gameOverSceneName;
    [SerializeField] string _resultSceneName;
    static public float _time;

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

    static public void Result()
    {
        _time = GameObject.FindObjectOfType<TimeCountManager>().TimeCount;
        SceneChange.LoadScene(Instance._resultSceneName);
    }
}
