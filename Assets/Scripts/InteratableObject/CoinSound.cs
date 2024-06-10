using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    sfxPlayer soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("sfxPlayer").GetComponent<sfxPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            soundManager.PlaySFXSound(sfxSoundType.GetCoin);
        }
    }
}
