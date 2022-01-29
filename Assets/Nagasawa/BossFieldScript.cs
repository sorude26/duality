using UnityEngine;
using System;

/// <summary>
/// ボス部屋の処理
/// </summary>
public class BossFieldScript : MonoBehaviour
{

    [Tooltip("必要なスコア"), SerializeField] int _bossScore;
    /// <summary>
    /// ボスフィールド解放時に呼ばれるイベント
    /// </summary>
    public static event Action OnBossField;

    void Update()
    {
        BossOpen();
    }

    /// <summary>
    /// ボス部屋開いた時の処理
    /// </summary>
    void BossOpen()
    {
        if (ScoreManager.CurrentScore >= _bossScore)
        {
            OnBossField?.Invoke();
        }
    }
}
