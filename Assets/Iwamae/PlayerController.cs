using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// スクリプト追加時Rigidbodyをオブジェクトに追加する
/// BoxColliderはプレイヤーの正面に配置する
/// </summary>
[RequireComponent(typeof(Rigidbody),(typeof(BoxCollider)))]

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動速度")] float m_speed = 5f;

    [SerializeField, Tooltip("プレイヤーのHP")] int m_playerHp = 3;

    [SerializeField, Tooltip("EnemyTag")] string m_enemyTag;

    [SerializeField, Tooltip("プレイヤーの回転速度")] float m_rtSpeed = 0.1f;

    /// <summary>
    /// コンポーネント用変数
    /// </summary>
    Rigidbody m_playerRb;

    /// <summary>
    /// コンポーネント用変数にRigidbodyを入れる
    /// </summary>
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

        //プレイヤーが移動していたら
        if (m_playerRb.velocity.magnitude > 0)
        {
            //正面をプレイヤーの移動している方向に向ける
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(m_playerRb.velocity),
                                                  m_rtSpeed);
        }

        Attack();
    }

    /// <summary>
    /// Fire1に指定しているボタンが押されたら
    /// プレイヤーについているBoxColliderを一瞬アクティブにする
    /// </summary>
    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Attck");
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    /// <summary>
    /// Enemytagがついてるオブジェクトに当たると死ぬ
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == m_enemyTag)
        {
            other.GetComponent<EnemyScript>().IsDeath = true;
        }
    }
}
