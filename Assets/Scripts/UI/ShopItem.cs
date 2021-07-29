using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : UIItem
{
    public TextMeshProUGUI priceText;

    private void Awake()
    {
        button.onClick += DisplayPurchaseConfirmation;
    }

    public void DisplayPurchaseConfirmation()
    {
        ShopPanel.Instance.DisplayConfirmationPanel(this);
    }
}
