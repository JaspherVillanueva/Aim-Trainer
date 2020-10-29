using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Runtime.InteropServices;

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
    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

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
    private void Update()
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

        //When the fire button is pressed and they arent spamming the fire button
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            //stop from firing
            nextTimeToFire = Time.time + 1f / fireRate;
            //then shoot
            Shoot();
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

    //this is called when the user presses 'fire1' or 'left mouse button'
    //the gun will shoot a raycast which will damage the targets if hit
    //and will only shoot if ammo is more than 0
    void Shoot()
    {
        //Bullet Tracer Animation
        Tracer.Play();
        //increment bullets shot for accuracy 
        GameManager.BulletsShot++;
        bulletsLeft--;

        Vector3 mouseScreenPosition = Input.mousePosition;
        Ray ray = fpsCamera.ScreenPointToRay(mouseScreenPosition);

        //if the gun is fired...
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //Store Hit target into a variable
            TargetMoving target = raycastHit.transform.GetComponent<TargetMoving>();

            if (target != null)
            {
                //make the target take damage
                target.TakeDamage(damage);
            }
        }


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
