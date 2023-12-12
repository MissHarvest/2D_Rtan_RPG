using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipableItem", menuName = "New Item/Equipable", order = 2)]
public class EquipableItemData : ItemData
{
    [Header("Equip")]
    public EquipablePart part;
    public bool isEquipped;

    EquipableItemData() : base(ItemType.Equipable) { }

}
