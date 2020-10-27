using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : ArduinoBehaviour
{
    public bool[] shooting = new bool[10];

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while(Arduino.isRunning)
        {
            for(int i = 0; i < 10; i++)
            {
                if(Game.Instance.players[i] && shooting[i])
                {
                    shooting[i] = false;
                    Shoot(i);
                }
            }
        }
        yield return null;
    }

    public void Shoot(int index)
    {
        for(int i = 0; i < Game.enemiesY; i++)
        {
            if(Game.Instance.enemies[index, i])
            {
                Game.Instance.enemies[index, i] = false;
                Team.GainPoints(10);
                return;
            }
            else
            {
                //Draw shoot in Game.Instance.enemies[index, i];
            }
        }
    }
}
