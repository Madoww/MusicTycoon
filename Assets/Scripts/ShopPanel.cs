using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private GameObject shopListRoot;
    [SerializeField] private TMP_Dropdown filter;

    private void OnEnable()
    {
        string[] enumNames = Enum.GetNames(typeof(ItemType));
        List<string> names = new List<string>(enumNames);

        filter.AddOptions(names);


        foreach(Item item in InventoryManager.Instance.allAvailableItems)
        {
            ShopItem shopItem = Instantiate(shopItemPrefab, shopListRoot.transform);
            shopItem.uiItem.name.SetText(item.name);
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
            shopItem.uiItem.name.SetText(item.name);
            shopItem.priceText.SetText(item.price.ToString());
        }
    }

    private void ResetList()
    {
        foreach (Transform child in shopListRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
