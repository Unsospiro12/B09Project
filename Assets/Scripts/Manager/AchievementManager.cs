using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementSO[] achievements;
    [SerializeField] private AchievementView achievementView;

    private int currentIdx; //현재 검사할 업적 번호

    private void Start()
    {
        achievementView.CreateAchievementSlots(achievements);
        GameManager.Instance.OnDeath += CheckAchievement;
    }
    public void CheckAchievement()
    {
        if (achievementView == null)
            return;
        //캐릭터가 죽으면 업적 처리 업데이트
        for (int i = 0; i < achievements.Length; i++)
        {
            float thresholdDistance = achievements[i].ThresholdDistance;
            int thresholdCoin = achievements[i].ThresholdCoin;

            switch (achievements[i].AchivementType)
            {
                case AchievementType.Distance:
                    if (GameManager.Instance.distance >= thresholdDistance)
                        achievementView.UnLock(i);
                    break;
                case AchievementType.Score:
                    if (GameManager.Instance.score >= thresholdCoin)
                        achievementView.UnLock(i);
                    break;
                case AchievementType.ScoreAndDistance:
                    if (GameManager.Instance.distance >= thresholdDistance && GameManager.Instance.score >= thresholdCoin)
                        achievementView.UnLock(i);
                    break;
            }
        }
    }
}
