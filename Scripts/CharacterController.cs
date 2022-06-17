using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] ParticleSystem confetti;
    private GameObject fadePanel;
    [SerializeField] ControllerStats _controller;
    [SerializeField] private LevelStats _levelStats;
    [SerializeField] Joystick myJoystick;
        private Vector2 _moveDir;
    [SerializeField] private Vector2 _moveDirsds;
    private float _movementSpeed = 2f;
    Rigidbody2D playerRb;
    private Vector2 spawnPos;
    [SerializeField] GameObject LeaderBoard;
    [SerializeField] GameObject shield;
    private bool isPlayerShield = false;
    private float shieldDuration = 2f;
    private float shieldTime = 0f;

    private float freezeDuration = 2f;
    private float freezeTime = 0f;

    public int tries = 0;

    [Header("Texts")]
    [SerializeField] Text LevelText;
    [SerializeField] Text TriesText;

    public float horizontal;
    public float vertical;

    Animator fadepanelAnim;

    private void Awake()
    {
        fadePanel = GameObject.FindGameObjectWithTag("fadepanel");
        fadepanelAnim = fadePanel.GetComponent<Animator>();
        _levelStats.isContinueMove = false;
        _levelStats.isLevelBegin = false;
       myJoystick = GameObject.FindGameObjectWithTag("joystick").GetComponent<Joystick>();
        playerRb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        LevelText.text = "Level " + SceneManager.GetActiveScene().name;
        tries = 1;
        TriesText.text = "Try: " + tries.ToString();
    }


    private void Update()
    {
        GetShield();
        DeFreezeLevel();
    }

    private void FixedUpdate()
    {
        
        if (_controller.joystick)
        {
            _moveDir = new Vector2(myJoystick.Horizontal, myJoystick.Vertical).normalized;
            playerRb.velocity = _moveDir * (_movementSpeed);
        }
        else
        {
            _moveDir = new Vector2(horizontal, vertical).normalized;
            playerRb.velocity = _moveDir * _movementSpeed;
        }
        if(playerRb.velocity != new Vector2(0,0) && !_levelStats.isLevelBegin)
        {
            _levelStats.isLevelBegin = true;
        }



    }
    public void GoDown()
    {
        vertical = -1;
    }
    public void GoUp()
    {
        vertical = 1;
    }
    public void GoRight()
    {
        horizontal = 1;
    }
    public void GoLeft()
    {
        horizontal = -1;
    }
    public void VerticalReset()
    {
        vertical = 0;
    }
    public void HorizontalReset()
    {
        horizontal = 0;
    }
    private void GetShield()
    {
        if (isPlayerShield && Time.time >= shieldTime)
        {
            isPlayerShield = false;
            shield.SetActive(false);
        }
    }

    private void DeFreezeLevel()
    {
        if (_levelStats.isLevelFreeze && Time.time >= freezeTime)
        {
            _levelStats.isLevelFreeze = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            if (!isPlayerShield)
            {
                fadepanelAnim.SetTrigger("fade");
                Vibration.Init();
                Vibration.VibratePop();
                transform.position = spawnPos;
                _levelStats.isLevelFreeze = false;
                tries++;
                TriesText.text = "Try: " + tries.ToString();

            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("shield"))
        {
            Vibration.Init();
            Vibration.VibratePop();
            Destroy(collision.gameObject);
            isPlayerShield = true;
            shield.SetActive(true);
            shieldTime = Time.time + shieldDuration;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("freeze"))
        {
            Vibration.Init();
            Vibration.VibratePop();
            Destroy(collision.gameObject);
            _levelStats.isLevelFreeze = true;
            freezeTime = Time.time + freezeDuration;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("king"))
        {
            Vibration.Init();
            Vibration.VibratePop();
            StartCoroutine(SpawnLeaderBoard());
            Instantiate(confetti, new Vector2(0, -4.55f), confetti.transform.rotation);
        }

    }
    IEnumerator SpawnLeaderBoard()
    {
            int index = 0;
            while (true)
            {
            yield return new WaitForSeconds(1.3f);
            LeaderBoard.SetActive(true);
            if (+index == 1) { yield break; }
            }
        
    }
}

