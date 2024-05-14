using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 aesteriod를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 aesteriod들을 인식할 수 있음.
    [SerializeField] private float radius = 10f;
    private float alertThreshold;

    private Animator animator;
    private static readonly int blinking = Animator.StringToHash("isBlinking");
    public Transform _aesteriod;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // FOV를 라디안으로 변환하고 코사인 값을 계산
    }


    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        // 주변 반경의 소행성들을 확인하고 이를 감지하여 Alert를 발생시킴(isBlinking -> true)

        animator.SetBool(blinking, IsTargetInSight());

    }

    bool IsTargetInSight()
    {
        //Debug.Log("InTarget");
        //타겟의 방향 
        Vector3 targetDir = (_aesteriod.position - transform.position).normalized;
        //Debug.Log("targetDir :" + targetDir);
        float distance = Vector2.Distance(_aesteriod.position, transform.position);
        float dot = Vector2.Dot(transform.up, targetDir);
        //Debug.Log("dot :" + dot);
        //내적을 이용한 각 계산하기
        // thetha = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;
        
        Debug.Log("타겟과 AI의 각도 :  "+ theta + "타겟과 AI의 거리 :" + distance);
        if (theta <= fov && distance < radius) return true;
        else return false;

    }

    private void BlinkBool2()
    {
        animator.SetBool(blinking, false);
    }


}