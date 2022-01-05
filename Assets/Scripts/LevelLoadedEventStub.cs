using System.Collections;
using Doozy.Engine;
using UnityEngine;

public class LevelLoadedEventStub : MonoBehaviour
{
    public void StubLoadLevel()
    {
        StopAllCoroutines();
        StartCoroutine(StubLoad());
    }

    private IEnumerator StubLoad()
    {
        yield return new WaitForSeconds(1f);
        GameEventMessage.SendEvent("LevelLoaded");
    }
}