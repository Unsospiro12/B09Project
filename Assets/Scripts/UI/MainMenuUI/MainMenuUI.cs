using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneNumber
{
    MainMenu,
    MainScene
}
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject achivementView;
    public void PopUpAchievement()
    {
        if(achivementView.activeInHierarchy)
            achivementView.SetActive(false);
        else if(!achivementView.activeInHierarchy)
            achivementView.SetActive(true);
    }
    public void StartGame()
    {
        GameManager.Instance.OnGameStart?.Invoke();
        SceneManager.LoadScene((int)SceneNumber.MainScene);
    }

    public void OnEasyMode()
    {
        GameManager.Instance.SetDifficulty(Difficulty.EASY);
    }
    public void OnNormalMode()
    {
        GameManager.Instance.SetDifficulty(Difficulty.NORMAL);
    }
    public void OnHardMode()
    {
        GameManager.Instance.SetDifficulty(Difficulty.HARD);
    }
}
