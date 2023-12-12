using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "New Item/Consumable", order = 1)]
public class ConsumableItemData : ItemData
{
    [Header("Stacking")]
    public bool canStack = true;
    public int maxStackCount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    ConsumableItemData() : base(ItemType.Consumable) { }
}
