using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmPurchasePanel : MonoBehaviour
{
    public ShopItem displayedItem;

    public void DisplayConfirmationPanel(ShopItem itemToConfirm)
    {
        gameObject.SetActive(true);
        displayedItem.name.text = itemToConfirm.name.text;
        displayedItem.priceText.text = itemToConfirm.priceText.text;
    }

    public void AttemptToPurchase()
    {
        if(GameManager.Instance.MoneyAmount > int.Parse(displayedItem.priceText.text))
        {
            GameManager.Instance.MoneyAmount -= int.Parse(displayedItem.priceText.text);
            InventoryManager.Instance.AddItem(displayedItem.name.text);
        }
    }
}
