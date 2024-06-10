using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;
    private Dictionary<int, AchievementSlot> achievementSlots = new Dictionary<int, AchievementSlot>();
    AchievementSlot achievementSlot;
    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        // achievement 데이터에 따라 슬롯을 생성함
        for (int i = 0; i < achievements.Length; i++)
        {
            achievementSlot = achievementSlotPrefab.GetComponent<AchievementSlot>();
            achievementSlot.Init(achievements[i]);
            AchievementSlot gameObject = Instantiate(achievementSlot, this.transform);
            achievementSlots.Add(i, gameObject);
        }
    }
    
    [ContextMenu("UnLock")]
    public void UnLock(int idx)
    {
        achievementSlots[idx].UnLockAchievement();
    }
}
