using UnityEngine;

[CreateAssetMenu(fileName = "AchievementSO", menuName = "AchievementData", order = 0)]
public class AchievementSO : ScriptableObject
{
    public int threshold;   // 대역 범위
    public string displayName;  // 보여줄 이름
    public string displayDesc;  // 보여줄 설명
    public bool isUnlocked;     // 잠금상태?
}