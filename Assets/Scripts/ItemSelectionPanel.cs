using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionPanel : MonoBehaviour
{
    [SerializeField] private UIItem itemPrefab;
    [SerializeField] private GameObject itemListRoot;

    public void Open(ItemType type)
    {
        gameObject.SetActive(true);
        foreach(Item item in InventoryManager.Instance.ownedItems)
        {
            if(item.type == type)
            {
                UIItem uiItem = Instantiate(itemPrefab, itemListRoot.transform);
                uiItem.type = type;
                uiItem.name.text = item.name;
            }
        }
    }

    public void Close()
    {
        foreach (Transform child in itemListRoot.transform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
}
