using UnityEngine;

public class TimeCountManager : MonoBehaviour
{
    float _time;

    public float TimeCount
    {
        get
        {
            return _time;
        }
    }
    void Start()
    {
        GameManager._time = 0;
    }

    void Update()
    {
        if (GameObject.FindObjectOfType<GameStartManager>())
        {
            return;
        }
        _time += Time.deltaTime;
    }
}
