using UnityEngine;

/// <summary>
/// エネミー処理
/// </summary>
public class EnemyScript : MonoBehaviour
{
    /// <summary>死亡したかどうか</summary>
    bool _isDeath;
    /// <summary>サークル内にいるかどうか</summary>
    bool _isPoint;
    /// <summary>
    /// 時間帯
    /// true 夜
    /// false 日が出ている
    /// </summary>
    bool _isTimeZone;
    [Header("設定項目")]
    [Tooltip("加算するポイント"), SerializeField] int _point;
    [Tooltip("サークルの名前"), SerializeField] string _pointName;

    //カプセル化

    /// <summary>死亡したかどうか カプセル化</summary>
    public bool IsDeath
    {
        set
        {
            _isDeath = value;
        }
    }

    /// <summary>
    /// 時間帯　カプセル化
    /// true 夜
    /// false 日が出ている
    /// </summary>
    public bool IsPoint
    {
        set
        {
            _isTimeZone = value;
        }
    }


    void Update()
    {
        Death();
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    void Death()
    {
        if(_isDeath)
        {
            if(_isPoint && !_isTimeZone)
            {
                PointUp();
            }
            else if(!_isPoint && _isTimeZone)
            {
                PointUp();
            }
            else
            {
                GameOver();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 成功
    /// ポイント加算
    /// </summary>
    void PointUp()
    {

    }

    /// <summary>
    /// 失敗
    /// ゲームオーバー
    /// </summary>
    void GameOver()
    {

    }

    /// <summary>
    /// サークル内にいるときの処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == _pointName)
        {
            _isPoint = true;
        }
        else
        {
            _isPoint = false;
        }
    }

    /// <summary>
    /// サークルから出た時の処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        _isPoint = false;
    }
}
