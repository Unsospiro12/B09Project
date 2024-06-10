using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    EASY,
    NORMAL,
    HARD
}
public class GameManager : Singleton<GameManager>
{
    public Player player;

    public Action OnDeath;
    public Action OnGameStart;

    public int coin;
    public int life;
    public int score;
    public float distance;//캐릭터가 총 움직인 거리

    public Difficulty difficulty = Difficulty.HARD;


    private void Start()
    {
        OnGameStart += ResetTimeScale;
        OnGameStart += StartGame;
        //플레이어가 장애물에 부딫히면 생명체크
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1.0f;
    }

    private void StartGame()
    {
        coin = 0;
        score = 0;
    }

    private void Update()
    {
        //초당 10미터
        GetDistance();
    }

    public void SetDifficulty(Difficulty value)
    {
        switch (value)
        {
            case Difficulty.EASY:
                life = 3;
                difficulty = Difficulty.EASY;
                break;
            case Difficulty.NORMAL:
                life = 2;
                difficulty = Difficulty.NORMAL;
                break;
            case Difficulty.HARD:
                life = 1;
                difficulty = Difficulty.HARD;
                break;
        }
    }

    public void GetDistance()
    {
        this.distance = player.distance;
    }
    public void CheckGameOver()
    {
        life -= 1;
        if (life <= 0)
            GameOver();
    }

    public void GameOver()
    {
        //죽음 이벤트 구독자에게 알림
        OnDeath?.Invoke();
        Time.timeScale = 0.0f;
        //TODO : UI까지 연동해서 Retry버튼 혹은 메인메뉴 버튼 생성    

    }
}
