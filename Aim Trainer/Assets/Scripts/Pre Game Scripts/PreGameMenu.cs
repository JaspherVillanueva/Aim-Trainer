using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PreGameMenu : MonoBehaviour
{
    public GameObject disableWeapon;
    public GameObject disableUI;
    public GameObject disableMenu;
    public GameObject disableBuyingMenu;

    public GameObject Canvas;

    void Start()  //disable UI elements, just show the menu
    {
        disableBuyingMenu.SetActive(false);
        disableWeapon.SetActive(false);
        disableUI.SetActive(false);
        disableMenu.SetActive(false);

        Time.timeScale = 0f;    //stop time

        Cursor.lockState = CursorLockMode.None; //unlock the cursor to press play
    }

    public void StartGame()
    {
        disableWeapon.SetActive(true);  //enable UI elements
        disableUI.SetActive(true);
        disableBuyingMenu.SetActive(true);
        disableMenu.SetActive(true);
        Canvas.SetActive(false);

        Time.timeScale = 1f; //continue time

        Cursor.lockState = CursorLockMode.Locked; //lock mouse to start game
    }
}
