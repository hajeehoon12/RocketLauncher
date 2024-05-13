using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeight : MonoBehaviour
{
    public GameObject _player;
    public AchievementManager _achievementManager;

    //public bool isTouched = false;

    private void Awake()
    {
        _achievementManager = GetComponentInParent<AchievementManager>();
    }

    private void Update()
    {
        



    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
        //Debug.Log("Collide!!");
        //if (other.gameObject.tag == "Player" && !isTouched)
        //{
            //Debug.Log("Yeah");
            //isTouched = true;
            //_achievementManager.CheckAchievement(transform.position.y);

        //}
    //}


}
