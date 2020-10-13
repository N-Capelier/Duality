#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultScript : ArduinoBehaviour
{
    void Start()
    {


        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (Arduino.isRunning)
        {
            yield return delay(10f);
        }
        yield return null;
    }
}
#endif