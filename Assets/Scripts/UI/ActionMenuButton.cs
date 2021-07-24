using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuButton : UIButton
{
    [SerializeField] private GameObject panelToOpen;

    private new void Start()
    {
        base.Start();
        onClick += OpenPanel;
    }

    private void OpenPanel()
    {
        PanelManager.Instance.OpenPanel(panelToOpen);
    }
}
