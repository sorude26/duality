using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamMove : MonoBehaviour
{
    [Header("移動時間x:最小値/y:最大値")]
    [SerializeField]
    Vector2 _moveTime = new Vector2(0.5f, 2f);
    [Header("待機時間x:最小値/y:最大値")]
    [SerializeField]
    Vector2 _waitTime = new Vector2(0.5f, 2f);
    [Header("移動方向")]
    [SerializeField]
    Vector3[] _moveDirs = { Vector3.right, Vector3.left, Vector3.forward, Vector3.back };
    [Header("移動速度")]
    [SerializeField]
    float _moveSpeed = 1f;
    float _timer = 0;
    bool _move = false;
    bool _back = false;
    Vector3 _moveDir = default;
    private void Start()
    {
        WaitMode();
    }
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_move)
        {
            transform.position = transform.position + _moveDir.normalized * _moveSpeed * Time.deltaTime;
            if (_timer < 0)
            {
                WaitMode();
            }
        }
        else
        {
            if (_timer < 0)
            {
                MoveMode();
            }
        }
    }
    void Turn()
    {
        transform.forward = _moveDir.normalized;
    }
    void DirSelect()
    {
        var s = Random.Range(0, _moveDirs.Length);
        _moveDir = _moveDirs[s];
        Turn();
    }
    void WaitMode()
    {
        DirSelect();
        _timer = Random.Range(_waitTime.x, _waitTime.y);
        _move = false;
        _back = false;
    }
    void MoveMode()
    {
        _timer = Random.Range(_moveTime.x, _moveTime.y);
        _move = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_back)
        {
            _moveDir = -_moveDir;
            Turn();
            _back = true;
        }
    }
}
