using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInventoryListElement : UIButton
{
    [SerializeField] private ItemType type;
    [SerializeField] private TextMeshProUGUI name;

    public ItemType Type
    {
        get => type;
    }

    public TextMeshProUGUI TMPName
    {
        get => name;
    }

    private void Awake()
    {
        onClick += OpenItemSelectionPanel;
    }

    public void OpenItemSelectionPanel()
    {
        InventoryManager.Instance.itemSelectionPanel.Open(type);
    }
}
