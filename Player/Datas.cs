using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Datas
{
    public int Stamina = 100;
    public int Health = 100;
    public string PlayerName = "Player1";

    public Datas(int stamina , int health , string playername)
    {
        this.Stamina = stamina;
        this.Health = health;
        this.PlayerName = playername;
    }
}
