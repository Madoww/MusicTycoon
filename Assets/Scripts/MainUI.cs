using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : Singleton<MainUI>
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = GameManager.Instance.MoneyAmount.ToString();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
