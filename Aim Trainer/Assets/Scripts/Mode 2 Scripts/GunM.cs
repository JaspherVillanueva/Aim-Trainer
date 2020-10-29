using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography;

/*
 * this script is used to contain the functionality
 * off all the firearms via aiming and firing as well
 * as the ammo/firerate
 */
public class GunM : MonoBehaviour
{
    [SerializeField] Text Ammo;

    //instantiating variables
    public float damage = 50f;
    private float range = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public LayerMask layerMask;

    private bool isReloading = false;
    private bool isAiming;

    public int magazineSize;
    private int bulletsLeft;
    public float reloadTime = 1f;

    public Camera fpsCamera;
    public ParticleSystem Tracer;
    public Animator animator;

    private Vector3 originalPosition;
    public Vector3 aimPosition;
    public float adsSpeed = 8f;


    void start()
    {
        //set current ammo (bullets left) to max bullets
        bulletsLeft = magazineSize;

        originalPosition = transform.localPosition;
    }

    void OnEnable()
    {
        //set reloading to false
        isReloading = false;
        //change animator boolean
        animator.SetBool("Reloading", false);
    }

    private void FixedUpdate()
    {
        animator.SetBool("Aim", isAiming);
    }

    //Update is called once per frame
    void Update()
    {

        /*
        Vector3 mouseScreenPosition = Input.mousePosition;
        Ray ray = fpsCamera.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            //Store Hit target into a variable
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(hit.transform.name);

            if (target != null)
            {
                //make the target take damage
                target.TakeDamage(damage);
            }
        }
        */



        //change text
        Ammo.text = bulletsLeft + " / " + magazineSize;

        //if reloading is true
        if (isReloading)
            //exit
            return;

        //if bullet below 0 
        if (bulletsLeft <= 0 || (Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize))
        {
            //reload
            StartCoroutine(Reload());
            //exit
            return;
        }

        //When the fire button is pressed and they arent spamming the fire button
        //if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Fire");
            //Bullet Tracer Animation
            Tracer.Play();
            //increment bullets shot for accuracy 
            GameManager.BulletsShot++;
            bulletsLeft--;

            Vector3 mouseScreenPosition = Input.mousePosition;
            Ray ray = fpsCamera.ScreenPointToRay(mouseScreenPosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                //Store Hit target into a variable
                TargetMoving target = hit.transform.GetComponent<TargetMoving>();
                Debug.Log(hit.transform.name);

                if (target != null)
                {
                    //make the target take damage
                    //Debug.Log("SHOTS SHOTS SHOTS");
                    target.TakeDamage(damage);
                }

            }
        }
        //Aim
        AimDownSights();
    }

    //this function is called when ammo reaches 0 or is less than magazine size 
    //and when user presses the 'r' key, this sets current bullets back to max magazine size.
    IEnumerator Reload()
    {
        //set reloading to true
        isReloading = true;
        //Debug.Log("Reloading...");

        //set animator boolean
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        //set animator boolean
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        //reload clip
        bulletsLeft = magazineSize;
        //stop reloading
        isReloading = false;
    }

    //called when user presses 'fire2' or 'right mouse button'
    //it changes the view of the gun model so you aim down its sights
    //when letting go of button, player will go back to standard hip fire
    private void AimDownSights()
    {
        if (Input.GetButton("Fire2") && !isReloading)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * adsSpeed);
            isAiming = true;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * adsSpeed);
            isAiming = false;
        }
    }
}