using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovementC : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 10f;
    private readonly float ROTATIONSPEED = 0.02f;
    private Animator _animator;
    public RocketControllerC rocketControllerC;

    public Transform _rocketControll;

    private float height = -1;

    public static Action<float> OnHighScoreChanged;
    
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rocketControll = GetComponent<Transform>();
        rocketControllerC = GetComponent<RocketControllerC>();
     
    }

    private void Start()
    {
        OnHighScoreChanged += AchievementManager.Instance.CheckAchievement;
    }


    private void FixedUpdate()
    {
        //if (!(highScore < transform.position.y)) return;
        //highScore = transform.position.y;
        //OnHighScoreChanged?.Invoke(highScore);
        //____________________________________________________________
        if (_rb2d.velocity.y < 0.5f && _rb2d.velocity.y >-0.5f && rocketControllerC._isMoving)
        {
            Debug.Log(transform.position.y);
            if (!(height < transform.position.y)) return;
            height = transform.position.y;
            OnHighScoreChanged?.Invoke(height);
        }
    }

    public void ApplyMovement(float inputX)
    {
        Rotate(inputX);
    }

    public void ApplyRoatation(float inputX)
    {
        //Quaternion.Slerp(_rocketControll.rotation,_rocketControll.rotation, );
    }


    public void ApplyBoost()
    {
        //Debug.Log("Test");
        _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
        _animator.SetBool("isBlinking", true);
        Invoke("BlinkBool", 1);


    }

    private void Rotate(float inputX)
    {
        // 움직임에 따라 회전을 바꿈 -> 회전을 바꾸고 그 방향으로 발사를 해야 그쪽으로 가겠죠?
        transform.Rotate(new Vector3(0,0, ROTATIONSPEED * Time.deltaTime * inputX));
    }

    private void BlinkBool()
    {
        _animator.SetBool("isBlinking", false);
    }

}