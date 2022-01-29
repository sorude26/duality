using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ���Ԃ��Ǘ�����X�N���v�g
/// </summary>

public class TimeManager : MonoBehaviour
{
    [SerializeField, Header("����")] float _count = 0.0f;

    // ���Ԃ𐮐��ɕϊ�����ϐ�
    int _second;

    // �Ԋu����
    const int _span = 10;

    [SerializeField, Header("���Ԃ�\������e�L�X�g")] Text _timeText;

    // �������ǂ����̔���
    bool isDayTime;

    // �邩�ǂ����̔���
    bool isNightTime;

    bool isDayRepeat;

    bool isNightRepeat;



    void Start()
    {
        // ���ɐݒ�
        isDayTime = true;

        // ���OFF�ɐݒ�
        isNightTime = false;

        isDayRepeat = false;

        isNightRepeat = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�A�b�v�J�n
        _count += Time.deltaTime;

        _second = (int)_count;

        // Text�ɕ\��
        _timeText.text = _second.ToString();

        if (_second > _span && isDayTime == true)
        {
            InvokeRepeating("Night", 10, _span);
        }
        if (_second > 2 *_span && isNightTime == true)
        {
            InvokeRepeating("Morning", 20, 2 * _span);
        }
    }

    void Night()
    {
        isDayTime = false;
        Debug.Log("��ɂȂ�܂���");
        isNightTime = true;
        CancelInvoke();
        
    }

    void Morning()
    {
        isNightTime = false;
        Debug.Log("���ɂȂ�܂���");
        isDayTime = true;
        CancelInvoke();
        
    }
}