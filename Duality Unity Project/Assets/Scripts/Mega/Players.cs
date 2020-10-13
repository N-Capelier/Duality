using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : ArduinoBehaviour
{
    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while(Arduino.isRunning)
        {
            //Check player inputs;

            yield return delay(0.1f);
        }
        yield return null;
    }

    void Shoot(int index)
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
