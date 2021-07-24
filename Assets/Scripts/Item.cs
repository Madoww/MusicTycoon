using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    microphone = 0,
    keyboard,
    headphones,
    software
}

[CreateAssetMenu(fileName = "Item", menuName = " Item")]
public class Item : ScriptableObject
{
    public new string name;
    public ItemType type;
    public Image icon;
    public float qualityMultiplier;
    public int price;
}
