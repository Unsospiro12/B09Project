using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene((int)SceneNumber.MainMenu);
    }
    public void Retry()
    {
        GameManager.Instance.OnGameStart?.Invoke();
        GameManager.Instance.SetDifficulty(GameManager.Instance.difficulty);
        SceneManager.LoadScene((int)SceneNumber.MainScene);
    }
}
