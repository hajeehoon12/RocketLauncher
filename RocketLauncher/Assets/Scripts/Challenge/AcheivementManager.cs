using System.Linq;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    private int currentThresholdIndex;

    [SerializeField] private AchievementSO[] achievements;
    [SerializeField] public AchievementView achievementView;
    [SerializeField] public RocketMovementC rocketMovementC;
    //private AchievementSlot _achievementSlot;

   

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (AchievementSO achive in achievements) achive.isUnlocked = false; // 체크를 위해 시작할때 업적 초기화
        //achievements = 
        achievementView.CreateAchievementSlots(achievements);  // UI 생성
    }

    // 최고 높이를 달성했을 때 업적 달성 판단, 이벤트 기반으로 설계할 것
    public void CheckAchievement(float height)
    {
        //Debug.Log(achievements[0].displayName);
        foreach (AchievementSO achive in achievements)
            if (!achive.isUnlocked)
            {
                if (height >= achive.threshold)
                {
                    achive.isUnlocked = true;
                    Debug.Log(achive.displayName);
                    achievementView.UnlockAchievement(achive, achive.threshold);
                    
                }
            }
    }
}