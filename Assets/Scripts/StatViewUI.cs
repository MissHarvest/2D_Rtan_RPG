using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatViewUI : MonoBehaviour
{
    [SerializeField] private CharacterStatHandler _playerStatHandler;

    public TextMeshProUGUI atkText;
    public TextMeshProUGUI critText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI speedTexxt;
    public TextMeshProUGUI lvText;

    private void Start()
    {
        var Player = GameManager.instance.Player;
        _playerStatHandler = Player.GetComponent<CharacterStatHandler>();
        atkText.text = _playerStatHandler.CurrentStat.attackSO.atk.ToString();
        critText.text = (_playerStatHandler.CurrentStat.attackSO.crit * 100).ToString() + " %";

        hpText.text = $"{Player.GetComponent<HealthSystem>().CurrentHealth} / {_playerStatHandler.CurrentStat.maxHealth}";
        Debug.Log("Player Speed : " + _playerStatHandler.CurrentStat.speed);
        speedTexxt.text = _playerStatHandler.CurrentStat.speed.ToString();

        var levelSystem = Player.GetComponent<LevelSystem>();
        lvText.text = $"{levelSystem.Level} ({levelSystem.CurrentExp} / {levelSystem.MaxExp})";
    }
}
