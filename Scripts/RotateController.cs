using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateController : MonoBehaviour
{
    [SerializeField] private LevelStats _levelStats;

    [SerializeField] float rotateSpeed = 50f;


    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

}
