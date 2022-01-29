using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    Transform _followTarget = default;
    [SerializeField]
    Transform _rotationTarget = default;
    [SerializeField]
    float _followSpeed = 1f;
    [SerializeField]
    float _rotationSpeed = 1f;

    private void FixedUpdate()
    {
        transform.forward = Vector3.Lerp(transform.forward, _rotationTarget.forward, _rotationSpeed);
        float speed = (transform.position - _followTarget.position).sqrMagnitude;
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, speed * _followSpeed);
    }
}
