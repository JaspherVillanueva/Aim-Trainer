using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography;
//using Debug = UnityEngine.Debug;

/*
 * this script is used to contain the functionality
 * off all the firearms via aiming and firing as well
 * as the ammo/firerate
 */
public class Gun : MonoBehaviour
{
    [SerializeField] Text Ammo;

    //instantiating variables
    public float damage = 50f;
    private float range = 100f;
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
    public float adsSpeed= 8f;


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

    void Update()
    {
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

        //When the fire button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            //Bullet Tracer Animation
            Tracer.Play();
            //increment bullets shot for accuracy 
            GameManager.BulletsShot++;
            bulletsLeft--;

            //create variable for raycasting
            Vector3 mouseScreenPosition = Input.mousePosition;
            Ray ray = fpsCamera.ScreenPointToRay(mouseScreenPosition);
            RaycastHit hit;
            //test in scene mode for raycast
            //Debug.DrawRay(ray.origin, ray.direction * range, Color.red);

            if (Physics.Raycast(ray, out hit, range, layerMask))
            {
                //if in rotating mode
                if (GenerateEnemies.Rotating == true)
                {
                    //get component from parent
                    Target target = hit.transform.GetComponentInParent<Target>();
                    if (target != null)
                    {
                        //make the target take damage
                        target.TakeDamage(damage);
                    }
                }
                else
                {
                    //get component
                    Target target = hit.transform.GetComponent<Target>();
                    if (target != null)
                    {
                        //make the target take damage
                        target.TakeDamage(damage);
                    }
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
