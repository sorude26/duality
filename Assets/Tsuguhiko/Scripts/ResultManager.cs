using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Resultシーンに移行した時Textに表示するスクリプト
/// </summary>

public class ResultManager : MonoBehaviour
{
    /// <summary>
    /// かかった時間を表示するText変数
    /// </summary>
    [SerializeField, Header("表示する経過時間のText")] Text _elapsed_time_text;

    /// <summary>
    ///  かかった時間の変数
    /// </summary>
    float _elapsed_time;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameManagerの_timeのから経過時間の結果を入れる
        GameManager._time = _elapsed_time;

        // かかった時間をTextに表示
        _elapsed_time_text.text = _elapsed_time.ToString();
    }
}
