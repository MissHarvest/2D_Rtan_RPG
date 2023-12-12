using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "SO/Attack/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack")]
    public int atk;
    public LayerMask target;
    public float delay;
    public float crit;

    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
