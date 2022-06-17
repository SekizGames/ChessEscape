using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController player;
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
    }

    public void GoDown()
    {
        player.vertical = -1;
    }
    public void GoUp()
    {
        player.vertical = 1;
    }
    public void GoRight()
    {
        player.horizontal = 1;
    }
    public void GoLeft()
    {
        player.horizontal = -1;
    }
    public void VerticalReset()
    {
        player.vertical = 0;
    }
    public void HorizontalReset()
    {
        player.horizontal = 0;
    }
}
