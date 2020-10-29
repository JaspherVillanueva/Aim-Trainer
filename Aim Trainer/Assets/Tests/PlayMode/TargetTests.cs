using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime;

public class TargetTests
{
    //private PlayerMovement playerM;
    private Target target;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Stair Master");
    }

    //[UnityTest]
    //public IEnumerator PlayerMovesLeft()
    //{
    //    playerM = Transform.FindObjectOfType<PlayerMovement>();

    //    yield return new WaitForSeconds(0.5f);
    //}

    [UnityTest]
    public IEnumerator TargetTakesDamage()
    {
        target = Transform.FindObjectOfType<Target>();

        target.TakeDamage(target.health);

        Assert.AreEqual(target.health, 0.0f);

        yield return new WaitForSeconds(0.5f);
    }

    [UnityTest]
    public IEnumerator TargetSpawnMatchesLimit()
    {
        target = Transform.FindObjectOfType<Target>();
        
        yield return new WaitForSeconds(2f);

        //Debug.Log("Objects ", GenerateEnemies.closeTarget_Obj);
        //Debug.Log("Enemies ", GenerateEnemies.CloseEnemies);

        //Assert.AreEqual(GenerateEnemies.closeTarget_Obj, GenerateEnemies.CloseEnemies );

        yield return new WaitForSeconds(0.5f);
    }

    /*
    [UnityTest]
    public IEnumerator TargetSpawnedOnStartup()
    {

        var enemyPrefab = Resources.Load("Tests/enemy");
        var enemySpawner = new GameObject().AddComponent<GenerateEnemies>();

        yield return null;

        var spawnedEnemy = GameObject.FindWithTag("Enemy");
        var prefabOfTheSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);

        Assert.AreEqual(enemyPrefab, prefabOfTheSpawnedEnemy);


        yield return new WaitForSeconds(0.5f);
    }
    */

}


