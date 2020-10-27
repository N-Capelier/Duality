using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;

public class Game : ArduinoBehaviour
{
    [Header("References")]
    public Players playersScript = null;

    [Header("Game")]
    public float tickRate = 2f;
    public int tick = 0;
    public int spawnTime = 1;

    [Header("Entities")]
    public bool[] players = new bool[10];

    public bool[,] enemies = new bool[enemiesX, enemiesY];

    // Consts
    public const int enemiesX = 10;
    public const int enemiesY = 5;

    #region Singleton

    private static Game instance;

    public static Game Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Game>();
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(Game).Name;
                    instance = obj.AddComponent<Game>();
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Makes the object a Singleton.
    /// </summary>
    protected bool CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
            return true;
        }
        else
        {
            Debug.LogError("Destroyed a non-unique gameObject named " + gameObject.name);
            Destroy(gameObject);
            return false;
        }
    }

    #endregion

    private void Awake()
    {
        CreateSingleton();
    }

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while(Arduino.isRunning)
        {
            UpdateEnemies();
            CreateEnemies();
            UpdateDisplay();
            yield return delay(tickRate);
            tick++;
            print("Tick");
        }
        yield return null;
    }

    void UpdateEnemies()
    {
        for(int i = 0; i < enemiesX; i++)
        {
            if(enemies[i, 0])
            {
                enemies[i, 0] = false;
                Team.LooseHP(1);
            }
        }

        for(int i = 0; i < enemiesX; i++)
        {
            for(int j = 1; j < enemiesY; j++)
            {
                if(enemies[i, j])
                {
                    enemies[i, j] = false;
                    enemies[i, j - 1] = true;
                }
            }
        }
    }

    void CreateEnemies()
    {
        if(tick == spawnTime)
        {
            int enemy1 = Random.Range(0, 12);
            int enemy2 = Random.Range(0, 12);
            while(Mathf.Abs(enemy1 - enemy2) <= 2)
            {
                enemy2 = Random.Range(0, 12);
            }

            enemies[enemy1, enemiesY - 1] = true;
            enemies[enemy2, enemiesY - 1] = true;

            spawnTime -= 10;
        }
    }

    //Arduino part
    void UpdateDisplay()
    {
        for(int i = 0; i < enemiesX; i++)
        {
            for(int j = 0; j < enemiesY; j++)
            {
                if(enemies[i,j])
                {
                    UduinoManager.Instance.sendCommand("SetStrip", i, j, 255, 0, 0, 255);
                }
                else
                {
                    UduinoManager.Instance.sendCommand("SetStrip", i, j, 0, 0, 0, 0);
                }
            }
        }
    }
}
