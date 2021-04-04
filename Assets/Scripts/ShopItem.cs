using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public UIItem uiItem;
    public TextMeshProUGUI priceText;

    public void Purchase()
    {
        InventoryManager.Instance.AddItem(uiItem.name.text);
    }
}
