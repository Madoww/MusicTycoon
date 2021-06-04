using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopPanel : Singleton<ShopPanel>
{
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private GameObject shopListRoot;
    [SerializeField] private TMP_Dropdown filter;
    [SerializeField] private ConfirmPurchasePanel confirmPurchasePanel;

    private void OnEnable()
    {
        string[] enumNames = Enum.GetNames(typeof(ItemType));
        List<string> names = new List<string>(enumNames);

        filter.AddOptions(names);


        foreach(Item item in InventoryManager.Instance.allAvailableItems)
        {
            ShopItem shopItem = Instantiate(shopItemPrefab, shopListRoot.transform);
            shopItem.name.SetText(item.name);
            shopItem.priceText.SetText(item.price.ToString());
        }
    }

    public void ApplyFilter()
    {
        ResetList();
        ItemType selectedType = (ItemType)Enum.Parse(typeof(ItemType), filter.captionText.text);

        foreach (Item item in InventoryManager.Instance.allAvailableItems)
        {
            if (item.type != selectedType)
                continue;
            ShopItem shopItem = Instantiate(shopItemPrefab, shopListRoot.transform);
            shopItem.name.SetText(item.name);
            shopItem.priceText.SetText(item.price.ToString());
        }
    }

    public void DisplayConfirmationPanel(ShopItem purchasedItem)
    {
        confirmPurchasePanel.DisplayConfirmationPanel(purchasedItem);
    }

    private void ResetList()
    {
        foreach (Transform child in shopListRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
