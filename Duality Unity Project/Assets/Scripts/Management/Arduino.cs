using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    public static bool isRunning = true;

    public static int[] LED_HP = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    public static int[] SONIC_SENSOR = { 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
    public static int[] LED_STRIP = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}