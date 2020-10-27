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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;                  //stop time
        Cursor.lockState = CursorLockMode.None;
        disableBuyingMenu.SetActive(false);
        disableWeapon.SetActive(false);
        disableUI.SetActive(false);
        disableMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        disableWeapon.SetActive(true);
        disableUI.SetActive(true);
        disableBuyingMenu.SetActive(true);
        disableMenu.SetActive(true);
        Canvas.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
