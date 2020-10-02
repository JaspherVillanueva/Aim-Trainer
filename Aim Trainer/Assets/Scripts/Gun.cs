using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Gun : MonoBehaviour
{
    [SerializeField] Text textComponent;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

    private bool isReloading = false;

    public int magazineSize = 30;
    private int bulletsLeft;
    public float reloadTime = 1f;

    public Animator animator;
    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;


    void Start()
    {
        bulletsLeft = magazineSize; 
    }
    
    private void Awake()
    {
        
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    private void Update()
    {
        textComponent.text = bulletsLeft + " / " + magazineSize;

        if (isReloading)
            return;

        if (bulletsLeft <= 0 || Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        //When the fire button is pressed and they arent spamming the fire button
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        bulletsLeft = magazineSize;
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
            Debug.Log(hit.transform.name);

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
    }
}
