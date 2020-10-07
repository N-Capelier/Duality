using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Team
{
    //Constants
    public const int MAX_HP = 10;

    //Variables
    public static int HP = MAX_HP;
    public static int score = 0;

    public static int LooseHP(int _HP)
    {
        if(HP - _HP <= 0)
        {
            HP = 0;
            //Stop the game
            Arduino.isRunning = false;
        }
        else
        {
            HP -= _HP;
        }
        UpdateHP();
        return HP;
    }

    public static int GainHP(int _HP)
    {
        if(HP + _HP >= MAX_HP)
        {
            HP = MAX_HP;
        }
        else
        {
            HP += _HP;
        }
        UpdateHP();
        return HP;
    }

    public static int UpdateHP()
    {

        return HP;
    }

    public static int GainPoints(int _points)
    {
        score += _points;
        return score;
    }

    public static void ResetGame()
    {
        HP = MAX_HP;
        score = 0;
    }

    public static void StartGame()
    {
        Arduino.isRunning = true;
    }
}