using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] itemSlotsUI;
    private InventorySystem _inventorySystem = null;
    [SerializeField] private GameObject _rootSlots;
    public InformationUI informationUI;

    private void Awake()
    {
        itemSlotsUI = new ItemSlotUI[18];
        itemSlotsUI = _rootSlots.GetComponentsInChildren<ItemSlotUI>();
        BindingFunctionToButton();

        _inventorySystem = GameManager.instance.Player.GetComponent<InventorySystem>();
        _inventorySystem.OnUpdateInventory += UpdateItemSlotUIs;
    }

    private void BindingFunctionToButton()
    {
        for(int i = 0; i < itemSlotsUI.Length; ++i)
        {
            itemSlotsUI[i].index = i;
            itemSlotsUI[i].OnClicked += ShowItemInformation;
        }
    }

    private void Start()
    {
       
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

    private void ShowItemInformation(int index)
    {
        _inventorySystem.selectedIndex = index;
        var itemSlot = _inventorySystem.slots[index];
        informationUI.Show(itemSlot.item);
    }

    private void OnEnable()
    {
        UpdateItemSlotUIs();
    }
}
