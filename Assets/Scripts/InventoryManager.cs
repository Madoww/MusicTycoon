using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> ownedItems = new List<Item>();
    public List<Item> allAvailableItems = new List<Item>();
    public List<Item> activeItems = new List<Item>();
    public List<UIInventoryListElement> activeItemsUI = new List<UIInventoryListElement>();
    public ItemSelectionPanel itemSelectionPanel;

    private void Start()
    {
        foreach(Item item in activeItems)
        {
            UpdateUI(item);
        }
#if UNITY_EDITOR
        ValidateItemIntegrity();
#endif
    }
    public void SetAsActive(string name)
    {
        SetAsActive(FindItemByName(name));
    }
    public void SetAsActive(Item newItem)
    {
        for(int i = 0; i<activeItems.Count; i++)
        {
            if(activeItems[i].type == newItem.type)
            {
                activeItems[i] = newItem;
                UpdateUI(newItem);
                return;
            }
        }

        activeItems.Add(newItem);
        UpdateUI(newItem);
    }

    public Item GetActiveItem(ItemType type)
    {
        foreach(Item item in activeItems)
        {
            if(item.type == type)
            {
                return item;
            }
        }
        return null;
    }

    public Item FindItemByName(string name)
    {
        foreach(Item item in allAvailableItems)
        {
            if(item.name == name)
            {
                return item;
            }
        }
        Debug.LogError("Item not found: " + name);
        return null;
    }

    public void AddItem(string name)
    {
        ownedItems.Add(FindItemByName(name));
    }

    private void UpdateUI(Item updatedItem)
    {
        foreach (UIInventoryListElement inventoryListElement in activeItemsUI)
        {
            if (updatedItem.type == inventoryListElement.Type)
            {
                inventoryListElement.TMPName.SetText(updatedItem.name);
                return;
            }
        }
    }

    private void ValidateItemIntegrity()
    {
        for(int i = 0; i<activeItems.Count; i++)
        {
            for(int j = 0; j<activeItems.Count; j++)
            {
                if (i == j)
                    break;
                else if(activeItems[i].type == activeItems[j].type)
                {
                    Debug.LogError("Two items of the same category active! " + "'" + activeItems[i].name + "'" + " & " + "'" + activeItems[j].name + "'" + " (" + activeItems[i].type + ")");
                }
            }
        }
    }
}
