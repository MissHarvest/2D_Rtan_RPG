using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quantityText;
    public GameObject EquipMark;
    public event Action<int> OnClicked;
    public int index = 0;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        quantityText = transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
        EquipMark = transform.Find("EquipMark").gameObject;

        Clear();
    }

    private void Start()
    {
        GetComponent<Button>()?.onClick.AddListener(CallShowItemInfo);
    }

    private void CallShowItemInfo()
    {
        OnClicked?.Invoke(index);
    }

    public void Init(ItemSlot itemSlot)
    {
        if (itemSlot.item == null || itemSlot.quantity == 0)
        {
            GetComponent<Button>().enabled = false;
            Clear();
            return;
        }

        icon.sprite = itemSlot.item.icon;
        icon.enabled = true;

        if(itemSlot.item is ConsumableItemData)
        {
            quantityText.text = itemSlot.quantity.ToString();
            quantityText.enabled = true;
        }
        else if(itemSlot.item is EquipableItemData)
        {
            bool bEquipped = ((EquipableItemData)itemSlot.item).isEquipped;
            EquipMark.SetActive(bEquipped);
        }
        
        GetComponent<Button>().enabled = true;
    }

    public void Clear()
    {
        icon.enabled = false;
        EquipMark.SetActive(false);
        quantityText.enabled = false;
    }
}
