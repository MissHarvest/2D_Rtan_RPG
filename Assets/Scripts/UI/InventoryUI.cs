using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] itemSlotsUI;
    private InventorySystem _inventorySystem = null;

    private void Awake()
    {
        itemSlotsUI = new ItemSlotUI[18];
        itemSlotsUI = GetComponentsInChildren<ItemSlotUI>();
    }

    private void Start()
    {
        _inventorySystem = GameManager.instance.Player.GetComponent<InventorySystem>();
        _inventorySystem.OnUpdateInventory += UpdateItemSlotUIs;
    }

    private void UpdateItemSlotUIs()
    {
        if(_inventorySystem)
        {
            for (int i = 0; i < itemSlotsUI.Length; ++i)
            {
                itemSlotsUI[i].Init(_inventorySystem.slots[i]);
            }
        }        
    }

    private void OnEnable()
    {
        UpdateItemSlotUIs();
    }
}
