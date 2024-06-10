using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private RankView rankView;
    [SerializeField] private Button registButton;
    [SerializeField] private GameObject GameOverUI;

    public void OnRegist()
    {
        if (playerNameInput.text.Length > 0 && (playerNameInput.text.Length < 8))
        {
            rankView.CreateRank(playerNameInput.text);
            registButton.interactable = false;
            GameOverUI.SetActive(true);
        }
    }
}
