using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : UIItem
{
    private void Awake()
    {
        button.onClick += SetSelfAsActiveItem;
    }

    public void SetSelfAsActiveItem()
    {
        InventoryManager.Instance.SetAsActive(name.text);
    }
}
