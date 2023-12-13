using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    private TextMeshProUGUI _itemNameText;
    private TextMeshProUGUI _itemDescriptionText;
    private TextMeshProUGUI _itemAbilityText;
    private Button _useButton;
    private Button _equipButton;
    private Button _unEquipButton;
    private Button _destroyButton;

    private void Awake()
    {
        //_itemIcon = transform.Find("ItemIcon").GetComponent<Image>();
        _itemNameText = transform.Find("ItemNameText").GetComponent<TextMeshProUGUI>();
        _itemDescriptionText = transform.Find("ItemDescriptionText").GetComponent<TextMeshProUGUI>();
        _itemAbilityText = transform.Find("ItemAbilityText").GetComponent<TextMeshProUGUI>();

        _useButton = transform.Find("UseButton").GetComponent<Button>();
        _equipButton = transform.Find("EquipButton").GetComponent<Button>();
        _unEquipButton = transform.Find("UnEquipButton").GetComponent<Button>();
        _destroyButton = transform.Find("DestroyButton").GetComponent<Button>();

        _useButton.onClick.AddListener(UseItem);
        _equipButton.onClick.AddListener(UseItem);
        _unEquipButton.onClick.AddListener(UseItem);

        Clear();
    }

    private void UseItem()
    {
        GameManager.instance.Player.GetComponent<InventorySystem>().UseItem();
    }

    public void Clear()
    {
        _itemIcon.gameObject.SetActive(false);
        _itemNameText.gameObject.SetActive(false);
        _itemDescriptionText.gameObject.SetActive(false);
        _itemAbilityText.gameObject.SetActive(false);
        _useButton.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(false);
        _unEquipButton.gameObject.SetActive(false);
        _destroyButton.gameObject.SetActive(false);
    }

    public void Show(ItemData item)
    {
        if (item == null) return;
        _itemIcon.sprite = item.icon;
        _itemNameText.text = item.displayName;
        _itemDescriptionText.text = item.description;
        _itemAbilityText.text = string.Empty;

        _destroyButton.gameObject.SetActive(true);

        switch(item)
        {
            case ConsumableItemData _:
                _useButton.gameObject.SetActive(true);
                foreach(var ability in ((ConsumableItemData)item).consumables)
                {
                    _itemAbilityText.text += $"{ability.type.ToString()} {ability.value}\n";
                }
                break;

            case EquipableItemData _:
                if(((EquipableItemData)item).isEquipped)
                {
                    _unEquipButton.gameObject.SetActive(true);
                }
                else
                {
                    _equipButton.gameObject.SetActive(true);
                }
                foreach (var ability in ((EquipableItemData)item).statModifiers)
                {
                    //_itemAbilityText.text += $"{ability.attackSO. .ToString()} {ability.value}\n";
                }
                break;
        }

        _itemIcon.gameObject.SetActive(true);
        _itemNameText.gameObject.SetActive(true);
        _itemDescriptionText.gameObject.SetActive(true);
        _itemAbilityText.gameObject.SetActive(true);
    }
}
