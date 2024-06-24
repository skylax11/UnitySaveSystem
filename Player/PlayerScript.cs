using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int stamina = 100;
    private int health = 100;
    private string playerName = "Player1";

    public static Datas data;

    void Awake() => data = new Datas(stamina, health, playerName);

}
