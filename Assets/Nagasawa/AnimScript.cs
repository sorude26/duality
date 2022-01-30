using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    bool _isRun;
    [SerializeField] bool _isPlayer;
    [SerializeField] Animator _anim;
    void Start()
    {

    }

    void Update()
    {
        if (_rb.velocity.magnitude > 0 && !_isRun)
        {
            _isRun = true;
            _anim.SetBool("Run", _isRun);
        }
        else if(_rb.velocity.magnitude == 0 && _isRun)
        {
            _isRun = false;
            _anim.SetBool("Run", _isRun);
        }

        //if(_isPlayer)
        //{
        //    _anim.SetBool("Attack", _isRun);
        //}
    }
}
