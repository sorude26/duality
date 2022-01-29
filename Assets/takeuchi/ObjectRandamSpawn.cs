using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandamSpawn : MonoBehaviour
{
    [Header("スポーンさせるObject")]
    [SerializeField]
    GameObject _spawnObjectPrefab = default;
    [Header("スポーンさせる場所")]
    [SerializeField]
    Transform[] _spawnPoints = default;
    /// <summary>
    /// 指定数までスポーンさせる
    /// </summary>
    /// <param name="number"></param>
    public void Spawn(int number)
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            int r = Random.Range(0, _spawnPoints.Length);
            var t = _spawnPoints[i];
            _spawnPoints[i] = _spawnPoints[r];
            _spawnPoints[r] = t;
        }
        for (int i = 0; i < number; i++)
        {
            if (i >= _spawnPoints.Length)
            {
                break;
            }
            var ob = Instantiate(_spawnObjectPrefab,transform);
            ob.transform.position = _spawnPoints[i].position;
        }
    }
}
