using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコア管理を行う
/// </summary>
public class ScoreManager
{
    /// <summary>
    /// 現在のスコア
    /// </summary>
    public static int CurrentScore { get; private set; }
    /// <summary>
    /// 得点加算時に呼ばれるイベント
    /// </summary>
    public static event Action OnAddScore;
    /// <summary>
    /// 得点を加算する
    /// </summary>
    /// <param name="score"></param>
    public static void AddScore(int score)
    {
        CurrentScore += score;
        OnAddScore?.Invoke();
    } 
    /// <summary>
    /// 得点をリセットする
    /// </summary>
    public static void ResetScore()
    {
        CurrentScore = 0;
    }
}
