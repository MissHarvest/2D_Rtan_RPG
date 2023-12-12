using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat _baseStat;
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (_baseStat.attackSO != null)
        {
            attackSO = Instantiate(_baseStat.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        UpdateStats((a, b) => b, _baseStat);

        if(CurrentStat.attackSO != null)
        {
            CurrentStat.attackSO.target = _baseStat.attackSO.target; // 필요한가?
        }

        foreach(var modifier in statModifiers)
        {
            switch(modifier.statsChangeType)
            {
                case StatsChangeType.Override:
                    UpdateStats((a, b) => b, CurrentStat);
                    break;

                case StatsChangeType.Add:
                    UpdateStats((a, b) => a + b, CurrentStat);
                    break;

                case StatsChangeType.Multiple:
                    UpdateStats((a, b) => a * b, CurrentStat);
                    break;
            }
        }
    }

    private void UpdateStats(Func<float, float, float> operation, CharacterStat newModifier)
    {
        CurrentStat.maxHealth = (int)operation(CurrentStat.maxHealth, newModifier.maxHealth);

        if (CurrentStat.attackSO == null || newModifier.attackSO == null) return;

        UpdateAttackStat(operation, newModifier);
    }

    private void UpdateAttackStat(Func<float, float, float> operation, CharacterStat newModifier)
    {
        CurrentStat.attackSO.atk = (int)operation(CurrentStat.attackSO.atk, newModifier.attackSO.atk);
        CurrentStat.attackSO.crit = operation(CurrentStat.attackSO.crit, newModifier.attackSO.crit);
        CurrentStat.attackSO.delay = operation(CurrentStat.attackSO.delay, newModifier.attackSO.delay);
    }

    public void AddStatModifier(CharacterStat newModifier)
    {
        statModifiers.Add(newModifier);
        UpdateCharacterStats();
    }

    public void RemoveStatModifier(CharacterStat newModifier)
    {
        statModifiers.Remove(newModifier);
        UpdateCharacterStats();
    }


}
