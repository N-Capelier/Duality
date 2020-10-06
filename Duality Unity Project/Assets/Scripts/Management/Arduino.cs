using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    public static bool isRunning = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
