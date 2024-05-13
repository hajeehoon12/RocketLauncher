using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements) // 동적 생성
    {
        // achievement 데이터에 따라 슬롯을 생성함
    }

    public void UnlockAchievement(int threshold) // 해금된 업적 표시
    {
        // UI 반영 로직
    }
}