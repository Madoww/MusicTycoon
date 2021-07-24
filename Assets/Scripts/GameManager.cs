using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int MoneyAmount
    {
        get => moneyAmount;
        set { moneyAmount = value; }
    }

    public List<Song> songs;

    private int moneyAmount = 1000;
}
