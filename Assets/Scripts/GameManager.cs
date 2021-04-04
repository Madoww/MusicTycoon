using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> panels = new List<GameObject>();
    public int MoneyAmount
    {
        get => moneyAmount;
        private set { }
    }


    public void DisableAllPanels()
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public List<Song> songs;

    private int moneyAmount;
}
