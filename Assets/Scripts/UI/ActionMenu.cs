using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMenu : Singleton<ActionMenu>, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<UIButton> buttons = new List<UIButton>();
    [SerializeField] private GameObject menu;

    private bool mouseInContact = false;

    private void Start()
    {
        foreach(UIButton button in buttons)
        {
            button.onClick += Close;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            menu.SetActive(true);
            menu.transform.position = Input.mousePosition;
        }
        if(Input.GetMouseButtonDown(0) && mouseInContact == false)
        {
            menu.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseInContact = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseInContact = false;
    }

    public void Close()
    {
        menu.gameObject.SetActive(false);
    }
}
