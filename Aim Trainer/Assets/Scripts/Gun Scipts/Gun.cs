using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class Gun : MonoBehaviour
{
    [SerializeField] Text Ammo = null;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

    private bool isReloading = false;

    public int magazineSize;
    private int bulletsLeft;
    public float reloadTime = 1f;
    public static float aimSpeed = 1f;

    public Camera fpsCamera;
    public ParticleSystem Tracer;
    public Animator animator;

    void start()
    {
        //set current ammo (bullets left) to max bullets
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
        if (bulletsLeft <= 0 || (Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize))
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
        
        //Bullet Tracer Animation
        Tracer.Play();
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
        //Tracer.Pause();
    }
}
