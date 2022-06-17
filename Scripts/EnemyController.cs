using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LevelStats _levelStats;

    [SerializeField] List<Vector2> movePoses;
    [SerializeField] int index = 0;
    [SerializeField] float duration = 4f;
    public int maxCount;

    private int onceControl = 0;
    private int movementKontrol = 0;

    [Header("Horse Settings")]
    [SerializeField] bool isHorse = false;
    Vector2 movedir;
    int Lmove = 0;
    [SerializeField] float waitDuration = 1f;
    float waitTime = 0f;

    [Header("Wave Settings")]
    [SerializeField] bool isWave = false;
    [SerializeField] float newDuration = 1f;
    bool levelbegin = false;
    private void Awake()
    {
        if (isHorse)
            CalculateMoveDir();
        maxCount = movePoses.Count -1 ;
    }

    private void FixedUpdate()
    {
        if (_levelStats.isLevelBegin && !levelbegin)
        {
            levelbegin = true;
            Movement();
        }
            
        if (levelbegin)
        {
            if (!_levelStats.isLevelFreeze)
                HorseMovement();

            if (_levelStats.isLevelFreeze)
            {
                DOTween.Kill(transform);
                onceControl = 1;
            }
            else if (!_levelStats.isLevelFreeze && onceControl == 1)
            {
                Movement();
                onceControl = 0;
            }

                
        }
       
    }

    private void Movement()
    {
        if (!isHorse && !isWave)
        {
            transform.DOMove(movePoses[index], duration).SetEase(Ease.Linear).OnComplete(() => Movement());
            index++;
            if (index > maxCount)
            {
                index = 0;
            }
        }
        else if (isWave)
        {
            transform.DOMove(movePoses[index], duration).SetEase(Ease.Linear).OnComplete(() => Movement());
            duration = newDuration;
            index++;
            if (index > maxCount)
            {
                index = 0;
            }
        }
    }
    private void HorseMovement()
    {
        
            if(Lmove == 2)
            {
                waitTime = Time.time + waitDuration;
                Lmove = 0;
            }
            if(Time.time >= waitTime)
            {
            transform.Translate(movedir * Time.deltaTime * duration);
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), movePoses[index]) <= 0.04)
            {
                index++;
                if (index > maxCount)
                {
                    index = 0;
                    CalculateMoveDir();
                }
                CalculateMoveDir();
                Lmove++;
            }
        }
            
    }

    private void CalculateMoveDir()
    {
        movedir = movePoses[index] - new Vector2(transform.position.x, transform.position.y);
    }
}
