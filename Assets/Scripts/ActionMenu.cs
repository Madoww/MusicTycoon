using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenu : Singleton<ActionMenu>
{
    [SerializeField] private GameObject menu;
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            menu.SetActive(true);
            menu.transform.position = Input.mousePosition;
        }
    }
}
