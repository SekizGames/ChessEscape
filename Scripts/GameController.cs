using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
public class GameController : MonoBehaviour
{
    [SerializeField] private LevelStats _levelStats;

    private GameObject door;
    Vector2 doorpos;

    [SerializeField] private string isDoorOpenDir;
    


    private void Awake()
    {
        Application.targetFrameRate = 60;
        DOTween.SetTweensCapacity(500, 50);
        DoorSystem();
        _levelStats.isLevelFreeze = false;
        GameAnalytics.Initialize();
    }

    private void Update()
    {
        if (_levelStats.isDoorOpen == true && door && isDoorOpenDir == "left")
        {
            if (door)
            {
                door.transform.DOMoveX(doorpos.x - 1.2f, 1f);
                Destroy(door, 2f);
                _levelStats.isDoorOpen = false;
            }
        }
        else if (_levelStats.isDoorOpen == true && door && isDoorOpenDir == "right")
        {
            if (door)
            {
                door.transform.DOMoveX(doorpos.x + 1.2f, 1f);
                Destroy(door, 2f);
                _levelStats.isDoorOpen = false;
            }
        }
        else if (_levelStats.isDoorOpen == true && door && isDoorOpenDir == "up")
        {
            if (door)
            {
                door.transform.DOMoveY(doorpos.y - 1.2f, 1f);
                Destroy(door, 2f);
                _levelStats.isDoorOpen = false;
            }
        }
        else if (_levelStats.isDoorOpen == true && door && isDoorOpenDir == "down")
        {
            if (door)
            {
                door.transform.DOMoveY(doorpos.y + 1.2f, 1f);
                Destroy(door, 2f);
                _levelStats.isDoorOpen = false;
            }
        }
    }

  
    private void DoorSystem()
    {
        _levelStats.isDoorOpen = false;
        door = GameObject.FindGameObjectWithTag("door");
        doorpos = door.transform.position;
    }


}
