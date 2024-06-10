using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingKnife : MonoBehaviour
{
    //임시 , 수정 요함
    sfxPlayer sound;

    private void Awake()
    {
        sound = GameObject.Find("sfxPlayer").GetComponent<sfxPlayer>();
    }

    void PlayBladeSound()
    {
        // 일시에 움직이기 때문에 
        // 해당 블록에 도착했을 때 반복적으로 재생해 주면 될듯하다.
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            sound.PlaySFXSound(sfxSoundType.BladeSound);
            // 충돌 처리 (게임 오버)
        }
    }
}
