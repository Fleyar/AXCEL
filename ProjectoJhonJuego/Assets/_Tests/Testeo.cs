using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

namespace Test.John
{
public class Testeo
{
    // A Test behaves as an ordinary method

    private GameObject John;
    private GameObject Tilemap;
    private GameObject Grunt;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("Level 1");
        
    }
    [Test] 
    public void TesteoSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator JohnSalta()
    {
        yield return new WaitForSeconds(2);

        John = GameObject.Find("John");
        Tilemap = GameObject.Find("Tilemap");

        Assert.That(John.transform.position.y > Tilemap.transform.position.y);
    }

    [UnityTest]
    public IEnumerator JohnCae()
    {
        yield return new WaitForSeconds(2);

        John = GameObject.Find("John");
        Tilemap = GameObject.Find("Tilemap");

        Assert.That(John.transform.position.y < Tilemap.transform.position.y);
    }


[TearDown]
public void TearDown()
{

 EditorSceneManager.UnloadSceneAsync("Level 1");
 
}
}
}
