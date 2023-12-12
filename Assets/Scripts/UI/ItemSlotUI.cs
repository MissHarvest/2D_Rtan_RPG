using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quantityText;
    public GameObject EquipMark;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        quantityText = transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
        EquipMark = transform.Find("EquipMark").gameObject;

        Clear();
    }

    public void Init(ItemSlot itemSlot)
    {
        if (itemSlot.item == null) return;
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
    }

    public void Clear()
    {
        icon.enabled = false;
        EquipMark.SetActive(false);
        quantityText.enabled = false;
    }
}
