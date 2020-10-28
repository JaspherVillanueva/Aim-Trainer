using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime;

public class GunTests
{
    //private PlayerMovement playerM;
    private Gun gun;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Aim Trainer");
    }

    /*

    [UnityTest]
    public IEnumerator GunShootsOneBullet()
    {
        gun = Transform.FindObjectOfType<Gun>();

        yield return new WaitForSeconds(2f);
        gun.Shoot();
        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(gun.bulletsLeft, gun.magazineSize - 1);
        yield return new WaitForSeconds(0.5f);
    }

    [UnityTest]
    public IEnumerator AmmoCheck()
    {
        gun = Transform.FindObjectOfType<Gun>();

        yield return new WaitForSeconds(2f);

        Assert.AreEqual(gun.bulletsLeft, gun.magazineSize);

        yield return new WaitForSeconds(0.5f);
    }

    [UnityTest]
    public IEnumerator GunReload()
    {
        yield return new WaitForSeconds(2f);
        gun = Transform.FindObjectOfType<Gun>();

        for(int i = 0; i < gun.magazineSize; i++)
        {
            gun.Shoot();
        }

        yield return new WaitForSeconds(1.5f);

        Assert.AreEqual(gun.bulletsLeft, gun.magazineSize);

        yield return new WaitForSeconds(0.5f);
    }

    */
}



