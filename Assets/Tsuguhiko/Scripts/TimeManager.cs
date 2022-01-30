using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  時間を管理するスクリプト
/// </summary>

public class TimeManager : MonoBehaviour
{
    [SerializeField, Header("時間")] float _count = 0.0f;

    // 時間を整数に変換する変数
    int _second;

    // 間隔時間
    const int _span = 10;

    [SerializeField, Header("時間を表示するテキスト")] Text _timeText;

    // 日中かどうかの判定
    bool isDayTime;

    // 夜かどうかの判定
    bool isNightTime;

    //bool isDayRepeat;

    //bool isNightRepeat;

    [Header("シーン上で使うLight")]
    [SerializeField]
    LightController[] _lightControllers;
    public bool IsNightTime
    {
        get
        {
            return isNightTime;
        }
    }

    void Start()
    {
        // 朝に設定
        isDayTime = true;

        // 夜をOFFに設定
        isNightTime = false;

        //isDayRepeat = false;

        //isNightRepeat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindObjectOfType<GameStartManager>())
        {
            return;
        }
        // カウントアップ開始
        _count += Time.deltaTime;

        _second = (int)_count;

        // Textに表示
        _timeText.text = _second.ToString();

        if (_second > _span && isDayTime == true)
        {
            InvokeRepeating("Night", 10, _span);
        }
        if (_second > 2 *_span && isNightTime == true)
        {
            InvokeRepeating("Morning", 20, 2 * _span);
        }
    }

    void Night()
    {
        isDayTime = false;
        isNightTime = true;
        ChangeLight();
        CancelInvoke();
        
    }

    void Morning()
    {
        isNightTime = false;
        isDayTime = true;
        ChangeLight();
        CancelInvoke();        
    }

    void ChangeLight()
    {
        if (_lightControllers == null)
        {
            return;
        }
        foreach (var light in _lightControllers)
        {
            light.ChangeTimeZone();
        }
    }
}
