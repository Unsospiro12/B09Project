using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI coinText;

    //게임종료시 리더보드 Active(true)
    [SerializeField] private GameObject LeaderBoard;

    private void Start()
    {
        //cointext는 코인을먹을때마다 이벤트로 처리
        GameManager.Instance.player.OnCoinHit += UpdateCoin;
        GameManager.Instance.OnDeath += PopUpLeaderBoard;
    }
    private void Update()
    {
        UpdateDistance();
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene((int)SceneNumber.MainMenu);
    }
    //게임종료 버튼
    public void OnEscape()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PopUpLeaderBoard()
    {
        if(LeaderBoard != null )
            LeaderBoard.SetActive(true);
    }

    private void UpdateDistance()
    {
        float distance = (float)Math.Truncate(GameManager.Instance.distance);
        distanceText.text = distance + " M";
    }

    private void UpdateCoin()
    { 
        coinText.text = GameManager.Instance.coin.ToString();
    }


}
