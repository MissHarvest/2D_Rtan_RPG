using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailUIController : MonoBehaviour
{
    public GameObject statPanel;
    public GameObject inventoryPanel;
    public Button statButton;
    public Button inventoryButton;

    private void Awake()
    {
        statPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    private void Start()
    {
        statButton.onClick.AddListener(OnClickStatButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    private void OnClickStatButton()
    {
        statPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    private void OnClickInventoryButton()
    {
        statPanel.SetActive(false);
        inventoryPanel.SetActive(true);
    }
}
