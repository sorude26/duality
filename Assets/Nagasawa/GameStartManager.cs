using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    float _count = 4;
    [SerializeField] Text _countDownText;

    void Start()
    {
        ScoreManager.ResetScore();
    }

    void Update()
    {
        _count -= Time.deltaTime;
        int i = (int)_count;
        _countDownText.text = i.ToString();
        if(i <= 0)
        {
            _countDownText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
