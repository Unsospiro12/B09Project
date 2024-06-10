using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//점수만 보는 업적, 거리만 보는 업적, 둘다 보는 업적
public enum AchievementType
{
    Score,
    Distance,
    Coin,
    ScoreAndDistance
}
[CreateAssetMenu(fileName = "Achievement", menuName = "New Achievement")]
public class AchievementSO : ScriptableObject
{
    public AchievementType AchivementType;
    public string Name;
    public string Desc;
    public int ThresholdScore;
    public float ThresholdDistance;
    public int ThresholdCoin;
    public bool isUnlocked;
    public GameObject Reward; //TODO : 보상? 생각해보기
}
