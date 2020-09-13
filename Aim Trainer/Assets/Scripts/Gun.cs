
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 60f;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //When the fire button is pressed and they arent spamming the fire button
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        //play the muzzleFlash animation
        muzzleFlash.Play();

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
