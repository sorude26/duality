using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int _score = 100;
    [SerializeField]
    GameObject _deadEffectPrefab = default;
    bool _dead = false;
    void Dead()
    {
        ScoreManager.AddScore(_score);
        if (_deadEffectPrefab)
        {
            Instantiate(_deadEffectPrefab).transform.position = transform.position;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_dead)
            {
                _dead = true;
                Dead();
            }
        }
    }
}
