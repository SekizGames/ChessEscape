using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;

    private void Awake()
    {
        settingsPanel = GameObject.FindGameObjectWithTag("settingspanel");
    }
    public void OpenS()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseS()
    {
        settingsPanel.SetActive(false);
    }
}
