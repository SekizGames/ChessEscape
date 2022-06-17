using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] AudioSource myAudio;
    [SerializeField] AudioClip coinClip;
    [SerializeField] AudioClip finishclip;
    [SerializeField] private LevelStats _levelStats;

    [SerializeField] private int maxCoin;


    private int collectedCoin;

    private void Awake()
    {
        myAudio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        maxCoin = 0;
        collectedCoin = 0;
        foreach (var coin in GameObject.FindGameObjectsWithTag("coin"))
        {
            maxCoin++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("coin"))
        {
            Vibration.Init();
            Vibration.VibratePop();
            Destroy(collision.gameObject);
            collectedCoin++;
            myAudio.PlayOneShot(coinClip);
            if(collectedCoin >= maxCoin)
            {
                _levelStats.isDoorOpen = true;
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("key"))
        {
            Vibration.Init();
            Vibration.VibratePop();
            Destroy(collision.gameObject);
                _levelStats.isDoorOpen = true;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("king"))
        {
            myAudio.PlayOneShot(finishclip);
        }
    }

}
