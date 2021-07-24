using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Button button;

    public event Action onClick;

    protected void Start()
    {
        button.onClick.AddListener(Invoke);
    }

    protected void Invoke()
    {
        onClick?.Invoke();
    }
}
