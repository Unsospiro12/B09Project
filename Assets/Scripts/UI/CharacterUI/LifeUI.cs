using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private GameObject lifePrefab;

    private void Start()
    {
        SetLifeUI();
        GameManager.Instance.player.OnObstacleHit += DestroyMylifeUI;
    }
    private void SetLifeUI()
    {
        int lifeCount = GameManager.Instance.life;

        for (int i = 0; i < lifeCount; i++)
        {
            Instantiate(lifePrefab, this.transform);
        }
    }

    private void DestroyMylifeUI()
    {
        Destroy(this.transform.GetChild(0).gameObject);
    }
}
