using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankView : MonoBehaviour
{
    //랭크 프리팹을 받아서 데이터를 넣고 생성
    [SerializeField] private GameObject rankPrefab;

    private Dictionary<string, float> ranks = new Dictionary<string, float>();

    private void Start()
    {
        if(DataManager.Instance.ranks != null)
            ranks = DataManager.Instance.ranks;
        InitRankView();
    }
    public void CreateRank(string name)
    {
        float distance = GameManager.Instance.distance;
        if (ranks.ContainsKey(name))
        {
            ranks[name] = ranks[name] < distance ? distance : ranks[name];
            return;
        }
        GameObject go = Instantiate(rankPrefab, this.transform);
        if (go.TryGetComponent<Rank>(out Rank rank))
        {
            rank.Init(name, distance);
            ranks.Add(name, GameManager.Instance.distance);
        }
        UpdateRank();
    }

    //데이터매니저에 데이터 전달
    private void UpdateRank()
    {
        DataManager.Instance.ranks = ranks;
        ranks = ranks.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    //데이터매니저에서 데이터를 불러와서 초기화
    private void InitRankView()
    {
        foreach (var rank in ranks)
        {
            GameObject go = Instantiate(rankPrefab, this.transform);
            if (go.TryGetComponent<Rank>(out Rank component))
            {
                component.Init(rank.Key, rank.Value);
            }
        }
    }
}
