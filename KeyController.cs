using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private LevelStats _levelStats;


    void Update()
    {
        if (_levelStats.isDoorOpen)
            Destroy(gameObject);
    }
}
