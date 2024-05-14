using TMPro;
using UnityEngine;

public class AchievementSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleTxt;
    [SerializeField] private TextMeshProUGUI descTxt;
    [SerializeField] private GameObject checkMark;
    public bool isUnlocked = false;
    public int threshold;




    private void Awake()
    {
        //Init(data);
        isUnlocked = false;
        checkMark.SetActive(false);
    }

    public void Update()
    {
        
    }



    public void Init(AchievementSO data) // 내용 초기화
    {
        
        titleTxt.text = data.displayName;
        descTxt.text = data.displayDesc;
        isUnlocked = data.isUnlocked;
        threshold = data.threshold;
        //checkMark.SetActive(true);

    }

    public void MarkAsChecked() // 조건 달성시 해금 및 활성화처리
    {

        if (isUnlocked)
        {
            checkMark.SetActive(true);
            gameObject.SetActive(true);
        }
        //else gameObject.SetActive(false);
    }
}