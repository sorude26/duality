using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// スクリプト追加時Rigidbodyをオブジェクトに追加する
/// </summary>
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの移動速度")] float m_speed = 5f;

    [SerializeField, Header("プレイヤーのHP")] int m_playerHp = 3;

    /// <summary>
    /// コンポーネント用変数
    /// </summary>
    Rigidbody m_playerRb;

    void Start()
    {
        m_playerRb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float i = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, i);
        m_playerRb.velocity = dir.normalized * m_speed;
    }
}
