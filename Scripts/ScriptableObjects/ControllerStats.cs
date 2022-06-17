using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "controller/Controller")]

public class ControllerStats : ScriptableObject
{
    [SerializeField] private bool _isDpad = false;

    [SerializeField] private bool _joystick = false;

    [SerializeField] private int _rank = 12573;


    public bool isDpad { get { return _isDpad; } set { _isDpad = value; } }

    public bool joystick { get { return _joystick; } set { _joystick = value; } }

    public int rank { get { return _rank; } set { _rank = value; } }


}
