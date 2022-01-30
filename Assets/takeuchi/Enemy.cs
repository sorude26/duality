using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int _score = 100;
    [SerializeField]
    int _killScore = 1;
    [SerializeField]
    GameObject _effectPrefab = default;
    [SerializeField]
    GameObject _deadEffectPrefab = default;
    [SerializeField]
    GameObject[] _models = default;
    bool _dead = false;
    bool _night = false;
    private void OnEnable()
    {
        EventManager.OnChangeTimeZone += ChangeTimeZone;
    }
    private void OnDisable()
    {
        EventManager.OnChangeTimeZone -= ChangeTimeZone;
    }
    public void ChangeTimeZone()
    {
        if (_night)
        {
            _night = false;
        }
        else
        {
            _night = true;
        }
        ChangeModel();
    }
    void AddScore()
    {
        if (_night)
        {
            Dead();
        }
        else
        {
            Buddhahood();
        }
        Destroy(gameObject);
    }
    void Buddhahood()
    {
        ScoreManager.AddScore(_score);
        if (_effectPrefab)
        {
            Instantiate(_effectPrefab).transform.position = transform.position;
        }
    }
    void Dead()
    {
        ScoreManager.AddKillScore(_killScore);
        if (_deadEffectPrefab)
        {
            Instantiate(_deadEffectPrefab).transform.position = transform.position;
        }
    }
    void ChangeModel()
    {
        if (_models.Length == 0)
        {
            return;
        }
        if (_night)
        {
            _models[1].SetActive(true);
            _models[0].SetActive(false);
        }
        else
        {
            _models[0].SetActive(true);
            _models[1].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_dead)
            {
                _dead = true;
                AddScore();
            }
        }
    }
}
