using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private GameObject checkMark;

    public void Init(AchievementSO data)
    {
        nameText.text = data.name;
        descText.text = data.Desc;
        data.isUnlocked = false;
        checkMark.SetActive(false); 
    }

    public void UnLockAchievement()
    {
        checkMark.SetActive(true);
    }
}
