using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/LevelStats")]

public class LevelStats : ScriptableObject
{
    [SerializeField] private bool _isDoorOpen = false;

    [SerializeField] private bool _isLevelFreeze = false;

    [SerializeField] private bool _isLevelBegin = false;

    [SerializeField] private bool _isContinueMove = true;


    public bool isDoorOpen { get { return _isDoorOpen; } set { _isDoorOpen = value; } }

    public bool isLevelFreeze { get { return _isLevelFreeze; } set { _isLevelFreeze = value; } }

    public bool isLevelBegin { get { return _isLevelBegin; } set { _isLevelBegin = value; } }

    public bool isContinueMove { get { return _isContinueMove; } set { _isContinueMove = value; } }
}
