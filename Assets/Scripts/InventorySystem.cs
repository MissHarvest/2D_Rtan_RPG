using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public ItemData item = null;
    public int quantity = 0;
    private int maxCount => ((ConsumableItemData)item).maxStackCount;

    public ItemSlot() { }
    public ItemSlot(ItemData itemData, int quantity)
    {
        item = itemData;
        this.quantity = quantity;
    }

    public void AddQuantity(int add)
    {
        quantity += add;
    }

    public bool IsEnough(int add)
    {
        return quantity + add < maxCount;
    }
}

public class InventorySystem : MonoBehaviour
{
    public ItemSlot[] slots;

    public Action OnUpdateInventory;

    // private EquipSystem _equipSystem;
    private HealthSystem _healthSystem;

    public ItemData testItemData;

    public int selectedIndex = 0;

    private void Awake()
    {
        Debug.Log("inven Awake");
        _healthSystem = GetComponent<HealthSystem>();

        slots = new ItemSlot[18];
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i] = new ItemSlot();
        }
        AddItem(testItemData, 1);
    }

    private void Start()
    {
        OnUpdateInventory?.Invoke();
    }

    public void AddItem(ItemData itemData, int quantity)
    {
        var itemSlot = new ItemSlot(Instantiate(itemData), quantity);
        AddItem(itemSlot);
    }

    public void AddItem(ItemSlot itemSlot)
    {
        if(itemSlot.item.type == ItemType.Consumable)
        {
            var slot = GetAddibleItemSlot(itemSlot);
            if(slot != null)
            {
                slot.AddQuantity(itemSlot.quantity);
                OnUpdateInventory?.Invoke();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();
        if(emptySlot != null)
        {
            emptySlot.item = itemSlot.item;
            emptySlot.quantity = itemSlot.quantity;
            OnUpdateInventory?.Invoke();
            return;
        }

        // ÀÎº¥Åä¸®°¡ °¡µæ Ã¡´Ù¸é . . . 
    }

    private ItemSlot GetAddibleItemSlot(ItemSlot itemSlot)
    {
        for(int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].item == itemSlot.item && slots[i].IsEnough(itemSlot.quantity))
            {
                return slots[i];
            }
        }
        return null;
    }

    private ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].item == null)
                return slots[i];
        }
        return null;
    }

    public void UseItem()
    {
        if (slots[selectedIndex].quantity <= 0) return;
        var item = slots[selectedIndex].item;
        switch(item)
        {
            case ConsumableItemData _:
                foreach(var consume in ((ConsumableItemData)item).consumables)
                {
                    if(consume.type == Consumable.Heath)
                    {
                        _healthSystem.ChangeHealth(consume.value);
                        slots[selectedIndex].quantity--;
                    }
                }
                break;

            case EquipableItemData _:
                foreach(var newModifier in ((EquipableItemData)item).statModifiers)
                {
                    if(((EquipableItemData)item).isEquipped)
                    {
                        GetComponent<CharacterStatHandler>().RemoveStatModifier(newModifier);
                    }
                    else
                    {
                        GetComponent<CharacterStatHandler>().AddStatModifier(newModifier);
                    }
                }
                ((EquipableItemData)item).isEquipped = !((EquipableItemData)item).isEquipped;
                break;
        }
        OnUpdateInventory?.Invoke();
    }
}
