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
    /// 現在の通常スコア
    /// </summary>
    public static int CurrentScore { get; private set; }
    /// <summary>
    /// 現在のキルスコア
    /// </summary>
    public static int CurrentKillScore { get; private set; }
    /// <summary>
    /// 現在の合算スコア
    /// </summary>
    public static int CurrentTotalScore { get => CurrentScore + CurrentKillScore; }
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
    /// キルスコアを加算する
    /// </summary>
    /// <param name="score"></param>
    public static void AddKillScore(int score)
    {
        CurrentKillScore += score;
        OnAddScore?.Invoke();
    }
    /// <summary>
    /// 得点をリセットする
    /// </summary>
    public static void ResetScore()
    {
        CurrentScore = 0;
        CurrentKillScore = 0;
    }
}
