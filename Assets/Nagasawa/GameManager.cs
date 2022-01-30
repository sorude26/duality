using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    [SerializeField] string _gameOverSceneName;
    [SerializeField] string _resultSceneName;
    [SerializeField] ObjectRandamSpawn[] _randamSpawns;
    [SerializeField] int _spawnNumber = 7;
    /// <summary>
    /// GameManager‚Ìƒ^ƒCƒ€
    /// </summary>
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
    void Start()
    {
        foreach (var spawns in _randamSpawns)
        {
            spawns.Spawn(_spawnNumber);
        }
        FadeController.StartFadeIn();
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
