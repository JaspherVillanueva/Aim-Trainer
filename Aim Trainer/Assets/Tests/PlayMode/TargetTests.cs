using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
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
        SceneManager.LoadScene("Aim Trainer");
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

    /*

    [UnityTest]
    public IEnumerator TargetSpawnedOnStartup()
    {
        
         var enemyPrefab = Resources.Load("Tests/enemy");
         var enemySpawner = new GameObject().AddComponent<GenerateEnemies>();
         enemySpawner.Construct(enemyPrefab, 0 , 1);

        yield return null;

        var spawnedEnemy = GameObject.FindWithTag("Enemy");
        var prefabOfTheSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);

        Assert.AreEqual(enemyPrefab, prefabOfTheSpawnedEnemy);
         

        yield return new WaitForSeconds(0.5f);
    }
    */
}

