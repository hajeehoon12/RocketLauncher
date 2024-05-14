using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();
    public Transform parents;
    private GameObject myInstance;
    public AchievementSlot achievementSlot;



    public void Start()
    {
        gameObject.SetActive(false);
    }


    public void CreateAchievementSlots(AchievementSO[] achievements) // 동적 생성
    {
        // achievement 데이터에 따라 슬롯을 생성함
        int numOfSlots = achievements.Length;

        for (int i = 0; i < numOfSlots; i++)
        {
            myInstance = Instantiate(achievementSlotPrefab, parents);
            myInstance.transform.position = parents.transform.position + new Vector3(0, -i * 1.5f, 0);
            myInstance.SetActive(false);
            achievementSlot = myInstance.GetComponent<AchievementSlot>();
            achievementSlot.Init(achievements[i]);
            achievementSlots.Add(i, achievementSlot);
            //myInstance
        }

        
    }

    public void UnlockAchievement(AchievementSO SO, int threshold) // 해금된 업적 표시
    {

        gameObject.SetActive(true);


        // UI 반영 로직
        foreach (KeyValuePair<int, AchievementSlot> item in achievementSlots)
        {
            if (threshold == item.Value.threshold)
            {
                item.Value.Init(SO);
                item.Value.MarkAsChecked();
            }
            
        }


        
        
    }
}