using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Debug = UnityEngine.Debug;

namespace Tests
{
    public class EditModeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SceneHasPlayer()
        {

            /*
            Player = GameObject.FindObjectOfType<Player>();

            Player play = (Player)FindObjectOfType<Player>(typeof(Player));
            if (play)
            {
                Debug.Log("Player object found: " + play.name);
            }
            else
            {
                Debug.Log("No player Object could be found");
            }
            */
            //Assert.That(Object.FindObjectOfType<Player>(), Is.Not.Null);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
