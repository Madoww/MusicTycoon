using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public List<GameObject> panels = new List<GameObject>();

    public void OpenPanel(int panelIndex)
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        panels[panelIndex].SetActive(true);
    }

    public void OpenPanel(GameObject panelObject)
    {
        foreach(GameObject panel in panels)
        {
            if(!panel.Equals(panelObject))
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }
}
