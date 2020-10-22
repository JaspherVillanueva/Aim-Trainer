using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PreGameMenu : MonoBehaviour
{
    public GameObject disableWeapon;
    public GameObject disableCrosshair;
    public GameObject disableScore;
    public GameObject disableAmmo;
    public GameObject disableMenu;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;

        disableWeapon.SetActive(false);
        disableCrosshair.SetActive(false);
        disableScore.SetActive(false);
        disableAmmo.SetActive(false);
        disableMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        disableWeapon.SetActive(true);
        disableCrosshair.SetActive(true);
        disableScore.SetActive(true);
        disableAmmo.SetActive(true);
        disableMenu.SetActive(true);
        Canvas.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
