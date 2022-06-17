using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoardGenerator : MonoBehaviour
{
    [SerializeField] ControllerStats controller;
    [SerializeField] List<Text> playerNames;
    [SerializeField] List<Text> retriesCount;
    [SerializeField] List<Text> ranks;
    [SerializeField] Text Me;
    private int playerTries;
    private int playerRank;

    void Start()
    {
        foreach (var item in playerNames)
        {
            item.text = NVJOBNameGen.GiveAName(Random.Range(1, 7));
        }

        SetTries();
        SetRanks();
        controller.rank = playerRank - Random.Range(50, 200);
    }

    private void SetTries()
    {
        playerTries = GameObject.FindObjectOfType<CharacterController>().tries;
        if (playerTries == 1)
            retriesCount[0].text = Random.Range(25,60).ToString();
        else
            retriesCount[0].text = (playerTries - 1).ToString();
        retriesCount[1].text = (playerTries + 1).ToString();
        retriesCount[2].text = (playerTries + 1).ToString();
        retriesCount[3].text = (playerTries + 1).ToString();
        retriesCount[4].text = (playerTries + 1).ToString();
        retriesCount[5].text = (playerTries).ToString();
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().name == "40")
        {
            SceneManager.LoadScene("1");
        }
        else
        SceneManager.LoadScene((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString());
    }

    private void SetRanks()
    {
        playerRank = controller.rank;
        ranks[0].text = (playerRank - 1).ToString();
        ranks[1].text = (playerRank + 1).ToString();
        ranks[2].text = (playerRank + 2).ToString();
        ranks[3].text = (playerRank + 3).ToString();
        ranks[4].text = (playerRank + 4).ToString();
        ranks[5].text = (playerRank).ToString();
    }

}
