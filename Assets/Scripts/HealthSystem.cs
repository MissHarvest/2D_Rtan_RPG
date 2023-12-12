using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private CharacterStatHandler _characterStatHandler;
    private LevelSystem _levelSystem;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => _characterStatHandler.CurrentStat.maxHealth;

    private void Start()
    {
        _characterStatHandler = GetComponent<CharacterStatHandler>();
        CurrentHealth = MaxHealth;

        _levelSystem = GetComponent<LevelSystem>();
        _levelSystem.OnLevelUp += (() => ChangeHealth(MaxHealth));
    }

    public void ChangeHealth(float change)
    {
        if (0 == change) return;


    }
}
