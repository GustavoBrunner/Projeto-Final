using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;
using Game.Combat;
using Game.Data;

public class UiController : TypeBroker
{
    [SerializeField] private TMP_Text PlayerHp;
    [SerializeField] private TMP_Text PlayerPosture;

    [SerializeField] private TMP_Text EnemyHp;
    [SerializeField] private TMP_Text EnemyPosture;


    private void Awake()
    {
        CombatEvents.onMissClick.AddListener(PlayerDamage);
        CombatEvents.onPassSkill.AddListener(EnemyDamage);

        HudCombatEvents.onUpdatePlayerData.AddListener(UpdatePlayerData);
        HudCombatEvents.onUpdateEnemyData.AddListener(UpdateEnemyData);
    }
    public void EnemyDamage(DamageTypes type, float value)
    {
        if(type == DamageTypes.none) return;
        if (type == DamageTypes.hp)
        {
            EnemyHp.text = value.ToString();
        }
        else
        {
            EnemyPosture.text = value.ToString();
        }
    }

    public void PlayerDamage(DamageTypes type, float value)
    {
        if (type == DamageTypes.none) return;
        if (type == DamageTypes.hp)
        {
            PlayerHp.text = value.ToString();
        }
        else
        {
            PlayerPosture.text = value.ToString();
        }
    }
    private void UpdatePlayerData(PlayerDto dto)
    {
        PlayerHp.text = dto.Hp.ToString();
        PlayerPosture.text = dto.Composture.ToString();
    }
    private void UpdateEnemyData(EnemyDto dto)
    {
        EnemyHp.text = dto.Hp.ToString();
        EnemyPosture.text = dto.Composture.ToString();
    }
}
