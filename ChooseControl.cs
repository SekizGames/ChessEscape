using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseControl : MonoBehaviour
{
    [SerializeField] ControllerStats _controller;
    [SerializeField] GameObject DpadYellow;
    [SerializeField] GameObject WasdYellow;
    [SerializeField] GameObject JoystickYellow;

    [SerializeField] GameObject WASD;
    [SerializeField] GameObject Dpad;
    [SerializeField] GameObject Joystick;

    void Start()
    {
        DpadYellow.SetActive(true);
        WasdYellow.SetActive(false);
        WASD = GameObject.FindGameObjectWithTag("wasd");
        Dpad = GameObject.FindGameObjectWithTag("dpad");
        Joystick = GameObject.FindGameObjectWithTag("joystick");

        if (_controller.isDpad && !_controller.joystick)
            SelectDpad();
        else if (!_controller.isDpad && !_controller.joystick)
            SelectWASD();
        else
            SelectJoystick();
        if (SceneManager.GetActiveScene().name != "1")
        {
            gameObject.SetActive(false);
        }
    }

   
   public void SelectWASD()
    {
        WASD.SetActive(true);
        WasdYellow.SetActive(true);
        DpadYellow.SetActive(false);
        JoystickYellow.SetActive(false);
        Dpad.SetActive(false);
        Joystick.SetActive(false);
        _controller.isDpad = false;
        _controller.joystick = false;
    }
    public void SelectDpad()
    {
        WASD.SetActive(false);
        WasdYellow.SetActive(false);
        DpadYellow.SetActive(true);
        JoystickYellow.SetActive(false);
        Dpad.SetActive(true);
        Joystick.SetActive(false);
        _controller.isDpad = true;
        _controller.joystick = false;
    }
    public void SelectJoystick()
    {
        WASD.SetActive(false);
        WasdYellow.SetActive(false);
        DpadYellow.SetActive(false);
        JoystickYellow.SetActive(true);
        Dpad.SetActive(false);
        Joystick.SetActive(true);
        _controller.joystick = true;
        _controller.isDpad = false;
    }
}
