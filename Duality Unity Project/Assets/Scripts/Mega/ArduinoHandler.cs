using System;
using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;

public class ArduinoHandler : ArduinoBehaviour
{
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += DataHandler;
    }

    void DataHandler(string data, UduinoDevice board)
    {
        string[] elements = data.Split('/');
        switch(elements[0])
        {
            case "echo":
                for(int i = 0; i < 10; i++)
                {
                    Game.Instance.players[i] = Convert.ToBoolean(elements[i + 1]);
                }
                break;
            case "photo":
                for(int i = 0; i < 10; i++)
                {
                    Game.Instance.playersScript.shooting[i] = Convert.ToBoolean(elements[i + 1]);
                }
                break;
            default:
                break;
        }
    }
}