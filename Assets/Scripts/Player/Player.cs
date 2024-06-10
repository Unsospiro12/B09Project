using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnCoinHit;
    public Action OnObstacleHit;
    public float distance;

    private void Awake()
    {
        FindPlayer(); 
    }

    private void Start()
    {
        OnObstacleHit += GameManager.Instance.CheckGameOver;
    }
    private void Update()
    {
        distance += Time.deltaTime * 10f;
    }
    public void FindPlayer()
    {
        GameManager.Instance.player = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        { 
            GameManager.Instance.coin += 1; 
            OnCoinHit?.Invoke();
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            OnObstacleHit?.Invoke();
        }
        else if(other.gameObject.CompareTag("Ocean"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
