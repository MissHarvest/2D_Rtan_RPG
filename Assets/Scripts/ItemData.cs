using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
}

public enum Consumable
{
    Heath,
    Magic,
}

public enum EquipablePart
{
    Head,
    Body,
    Weapon,
}

[System.Serializable]
public class ItemDataConsumable
{
    public Consumable type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Default", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    protected ItemData(ItemType itemType)
    {
        type = itemType;
    }
}