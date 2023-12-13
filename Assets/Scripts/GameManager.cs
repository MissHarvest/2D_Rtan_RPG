using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Player;
    public GameObject UI;
    public Action OnGameStart;

    private GameManager()
    {

    }

    private void Awake()
    {
        instance = this;
        Debug.Log("GameManager Awake");
        Player = Instantiate(Resources.Load<GameObject>("Player"));
        //Player = new GameObject("@Player");
        //Player.AddComponent<InventorySystem>();

        Instantiate(UI);
        Debug.Log("GameManager Awake End");
    }

    private void Start()
    {
        Debug.Log("GameManager Start");
        OnGameStart?.Invoke();

        //Player.SetActive(true);
        Debug.Log("GameManager Start End");
    }
}
