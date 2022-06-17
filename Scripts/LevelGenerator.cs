using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    private int playerTries;
    [SerializeField] bool player1 = false;
    void Start()
    {
        playerTries = GameObject.FindObjectOfType<CharacterController>().tries;
        if (playerTries == 1 && player1)
            GetComponent<Text>().text = (int.Parse(SceneManager.GetActiveScene().name) + 1).ToString();
        else
            GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }


}
