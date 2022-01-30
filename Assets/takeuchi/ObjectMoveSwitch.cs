using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMoveSwitch : MonoBehaviour
{
    [SerializeField]
    Transform _startPosition = default;
    [SerializeField]
    Transform _endPosition = default;
    [SerializeField]
    GameObject _moveObject = default;
    [SerializeField]
    Transform _barObject = default;
    [SerializeField]
    float _moveSpeed = 1f;
    bool _on = false;
    bool _move = false;
    IEnumerator Move()
    {
        if (_on)
        {
            _moveObject.transform.position = _endPosition.position;
            _barObject.localRotation = Quaternion.Euler(-65, 0, 0);
        }
        else
        {
            _moveObject.transform.position = _startPosition.position;
            _barObject.localRotation = Quaternion.Euler(65, 0, 0);
        }
        float timer = 0;
        while (timer < 1f)
        {
            timer += _moveSpeed * Time.deltaTime;
            if (timer > 1)
            {
                timer = 1;
            }
            Move(timer);
            yield return null;
        }
        Move(_on);
        _move = false;
    }
    void Move(float time)
    {
        if (!_on)
        {
            _moveObject.transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, time);
        }
        else
        {
            _moveObject.transform.position = Vector3.Lerp(_endPosition.position, _startPosition.position, time);
        }
    }
    void Move(bool on)
    {
        if (!_on)
        {
            _moveObject.transform.position =  _endPosition.position;
            _on = true;
        }
        else
        {
            _moveObject.transform.position = _startPosition.position;
            _on = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_move)
            {
                _move = true;
                StartCoroutine(Move());
            }
        }
    }
}
