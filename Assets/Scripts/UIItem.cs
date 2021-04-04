using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItem : MonoBehaviour
{
    public new TextMeshProUGUI name;
    public ItemType type;

    public void OpenItemSelectionPanel()
    {
        InventoryManager.Instance.itemSelectionPanel.Open(type);
    }

    public void SetSelfAsActiveItem()
    {
        InventoryManager.Instance.SetAsActive(name.text);
    }
}
