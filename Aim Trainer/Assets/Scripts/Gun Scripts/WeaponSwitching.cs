using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

/*
 * This class allows the user to switch between
 * weapons in the current loadout
 */
public class WeaponSwitching : MonoBehaviour
{
    //instantiating variables
    public int selectedWeapon = 0;
    public bool Ak = true;
    public bool SK = true;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    //update is called once every frame...
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        //the user is able to use the scroll wheel to switch between weapons
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //if the weapon is the maximum weapon in loadout
            if(selectedWeapon >= transform.childCount - 1)
            {
                //reset loadout to the start
                selectedWeapon = 0;
            }
            else
            {
                //otherwise increase loadout
                selectedWeapon++;
            }
        }

        //the user is able to use the scroll wheel to switch between weapons
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //if the weapon is the minimum weapon in loadout
            if (selectedWeapon <= 0)
            {
                //reset loadout out to the end
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                //otherwise decrease loadout
                selectedWeapon--;
            }
        }

        //this allows the user to switch between weapons when the user presses down on 1....
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Ak == true)
            {
                selectedWeapon = 0;
            }
            if (Ak != true)
            {
                selectedWeapon = 1;
            }
        }
        //.....or 2 on the keyboard
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if (SK == true)
            {
                selectedWeapon = 2;
            }
            if (SK != true)
            {
                selectedWeapon = 3;
            }
        }
        //if the user hasnt switched weapons then select a weapon
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }


    public void setPrimaryWeapon1()
    {
            Debug.Log("AK");
            Ak = true;
            selectedWeapon = 0;

        SelectWeapon();
        //GameObject.FindWithTag("AK-47").SetActive(true);
            //GameObject.FindWithTag("M4").SetActive(false);
    }

    public void setPrimaryWeapon2()
    {
            Debug.Log("M4");
            Ak = false;
            selectedWeapon = 1;

            SelectWeapon();
    }

    public void setSecondaryWeapon1()
    {
            Debug.Log("Sk");
            SK = true;
    }

    public void setSecondaryWeapon2()
    {
            Debug.Log("M19");
            SK = false;
    }


    //this function is called when the user is selecting a gun
    //it deactivates all the other guns besides the on the user is currently on
    void SelectWeapon()
    {
        int i = 0;

        //for each child of the weapon loadout
        foreach(Transform weapon in transform)
        {
            //if the seleceted weapon is true
            if (i == selectedWeapon)
            {
                //then activate weapon
                weapon.gameObject.SetActive(true);
            }
            //else
            else
            {
                //deactivate weapon
                weapon.gameObject.SetActive(false);
            }
            //go through the rest of the loadout
            i++;
        }
    }
}
