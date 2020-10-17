using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Gun : MonoBehaviour
{
    [SerializeField] Text Ammo;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

    private bool isReloading = false;

    public int magazineSize;
    private int bulletsLeft;
    public float reloadTime = 1f;
    public float aimSpeed = 1f;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public Animator animator;

    public WeaponSwitching Weapon;



    void start()
    {
        //set bullets left max bullets
        bulletsLeft = magazineSize;
    }

    void OnEnable()
    {
        //set reloading to false
        isReloading = false;
        //change animator boolean
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    private void Update()
    {
        //change text
        Ammo.text = bulletsLeft + " / " + magazineSize;

        //if reloading is true
        if (isReloading)
            //exit
            return;

        //if bullet below 0 
        if (bulletsLeft <= 0 || Input.GetKey(KeyCode.R))
        {
            //reload
            StartCoroutine(Reload());
            //exit
            return;
        }

        //When the fire button is pressed and they arent spamming the fire button
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            //stop from firing
            nextTimeToFire = Time.time + 1f / fireRate;
            //then shoot
            Shoot();
        }

        if (Input.GetMouseButton(1))
        {
            Aim();
        }
    }

    //reloading
    IEnumerator Reload()
    {
        //set reloading to true
        isReloading = true;
        Debug.Log("Reloading...");

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


    void Shoot()
    {
        //play the muzzleFlash animation
        muzzleFlash.Play();
        bulletsLeft--;

        RaycastHit hit;
        //if the gun is fired...
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            //output object shot
            //Debug.Log(hit.transform.name);

            //if target is hit...
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                //make the target take damage
                target.TakeDamage(damage);
            }

            //if the object hit is rigidbody...
            if (hit.rigidbody != null)
            {
                //make the object move back
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
        muzzleFlash.Pause();
    }

    public void Aim()
    {
        GameObject t_anchor = Weapon.selectedWeapon.transform.Find("anchor");
    }
}
