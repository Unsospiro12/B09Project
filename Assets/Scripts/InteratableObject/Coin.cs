using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    sfxPlayer sfxPlayer;

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<Player>();
        sfxPlayer = GameObject.Find("sfxPlayer").GetComponent<sfxPlayer>();

        player.OnCoinHit += PlayGetCoinSound;
    }

    private void PlayGetCoinSound()
    {
        sfxPlayer.PlaySFXSound(sfxSoundType.GetCoin);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
