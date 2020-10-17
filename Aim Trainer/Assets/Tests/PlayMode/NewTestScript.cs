using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime;

public class TestSuite
{
    private PlayerMovement playerM;
    private Target target;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Aim Trainer");
    }

    //[UnityTest]
    //public IEnumerator PlayerMovesLeft()
    //{
    //    playerM = Transform.FindObjectOfType<PlayerMovement>();

    //    yield return new WaitForSeconds(0.5f);
    //}

    [UnityTest]
    public IEnumerator TargetDestroyedWhenShot()
    {
        target = Transform.FindObjectOfType<Target>();
        
        target.TakeDamage(target.health);

        Assert.IsNull(target);

        yield return new WaitForSeconds(0.5f);
    }


}

