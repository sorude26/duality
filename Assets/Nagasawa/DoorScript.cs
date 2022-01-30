using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator _anim;
    [SerializeField] string _animName;
    BoxCollider _boxCollider;
    void Start()
    {
        _anim = GetComponent<Animator>();
        BossFieldScript.OnBossField += DoorAnim;
        _boxCollider = GetComponent<BoxCollider>();
    }
    public void DoorAnim()
    {
        _anim.Play(_animName);
        _boxCollider.enabled = true;
        BossFieldScript.OnBossField -= DoorAnim;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            SceneChange.LoadScene("KingsField");
        }
    }
}
