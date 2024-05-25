using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    public void TurnOnSettingMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }    
    public void ClosedSettingMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }   
    public void ExitGamePlay()
    {
        Application.Quit();
    }    
}
