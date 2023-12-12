using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int Level { get; private set; }
    private const int MaxLevel = 10;

    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }

    private int[] _expByLevel = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 , 0 };

    public event Action OnLevelUp;

    private void Awake()
    {
        Level = 1;
        MaxExp = _expByLevel[Level];
    }

    private void Init()
    {
        // PlayerPrefab.Get Level, exp
    }

    public void GetExp(int exp)
    {
        if (IsMaxLevel()) return;

        // 경험치 획득
        CurrentExp += exp;

        // 초과 확인
        while (!IsMaxLevel() && CurrentExp >= MaxExp)
        {
            CurrentExp -= MaxExp;
            ++Level;
            try
            {
                MaxExp = _expByLevel[Level];
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log("최대 레벨 일지도?");
            }
            OnLevelUp?.Invoke();
        }
    }

    public bool IsMaxLevel()
    {
        return MaxLevel == Level;
    }
}
