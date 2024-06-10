using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI distanceText;

    public void Init(string name, float distance)
    {
        nameText.text = name;
        distance = (float)Math.Truncate(distance);
        distanceText.text = $"{distance.ToString()} M";
    }
}
