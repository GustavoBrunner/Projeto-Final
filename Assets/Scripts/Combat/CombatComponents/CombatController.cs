using Game.Combat.ExtensionsMethods;
using Game.Controllers;
using Game.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class CombatController : MonoBehaviour
    {
        public bool IsCombat { get; private set; }

        [SerializeField] private PlayerDto PlayerData;

        [SerializeField] private EnemyDto EnemyData;

        [SerializeField] private CombatPhase CombatPhase;
        private void Awake()
        {
            CombatEvents.onCircleClicked.AddListener(CircleClicked);
            CombatEvents.onCombatCalled.AddListener(OnCombatStart);
        }

        private void StartCombat(EnemyTypes enemyType)
        {
            IsCombat = true;
            CombatEvents.onCombatStarted.Invoke(enemyType, this.CombatPhase);
        }
        public void StopCombat()
        {
            IsCombat = false;
            CombatEvents.onCombatFinished.Invoke();
        }

        private void CircleClicked(bool result)
        {
            if(result)
            {
                Debug.Log("Ataque certo");
                /* 
                 * se o inimigo tomar o dano, o dano vai na postura. Se a diferença entre o dano e a postura
                 * ser menor que 0, essa diferença vai ser guardada em outra variável e será mandada para a vida
                 */
                if(EnemyData.Composture - PlayerData.Damage <= 0)
                {
                    var left = Mathf.Abs(EnemyData.Composture - PlayerData.Damage);
                    if(left > 0)
                    {
                        EnemyData.Composture = 0f;
                        CombatEvents.onPassSkill.Invoke(DamageTypes.posture, EnemyData.Composture);

                        EnemyData.Hp -= left;
                        CombatEvents.onPassSkill.Invoke(DamageTypes.hp, EnemyData.Hp);
                        left = 0;
                    }
                    else
                    {
                        EnemyData.Hp -= PlayerData.Damage;
                        CombatEvents.onPassSkill.Invoke(DamageTypes.hp, EnemyData.Hp);
                    }

                }
                else
                {
                    EnemyData.Composture -= PlayerData.Damage;
                    CombatEvents.onPassSkill.Invoke(DamageTypes.posture, EnemyData.Composture);
                }
            }
            else
            {
                Debug.Log("Ataque errado");
                if (PlayerData.Composture - EnemyData.Damage >= 0)
                {
                    //compostura continua absorvendo o dano
                    PlayerData.Composture -= EnemyData.Damage;
                    CombatEvents.onMissClick.Invoke(DamageTypes.posture, PlayerData.Composture);
                    return;
                }
                var left = Mathf.Abs(PlayerData.Composture - EnemyData.Damage);
                if(left > 0)
                {
                    PlayerData.Composture = 0f;
                    CombatEvents.onMissClick.Invoke(DamageTypes.posture, PlayerData.Composture);

                    PlayerData.Hp -= left;
                    CombatEvents.onMissClick.Invoke(DamageTypes.hp, PlayerData.Hp);
                    left = 0f;
                    return;
                }
                PlayerData.Hp -= EnemyData.Damage;
                CombatEvents.onMissClick.Invoke(DamageTypes.hp, PlayerData.Hp);
            }
        }

        private void OnCombatStart(List<EnemyDto> enemyDtos, PlayerDto playerDto)
        {
            foreach(EnemyDto enemyDto in enemyDtos)
            {
                EnemyData.Composture += enemyDto.Composture;
                EnemyData.Hp += enemyDto.Hp;
                EnemyData.Damage += enemyDto.Damage;
            }
            EnemyData.enemyType = enemyDtos[0].enemyType;

            //call event to send the enemy data to the combat hud
            HudCombatEvents.onUpdateEnemyData.Invoke(EnemyData);


            PlayerData.Composture += playerDto.Composture;
            PlayerData.Hp += playerDto.Hp;
            PlayerData.Damage += playerDto.Damage;

            //call event to send the player data to the combat hud
            HudCombatEvents.onUpdatePlayerData.Invoke(PlayerData);

            if(EnemyData.Composture > PlayerData.Composture)
            {
                CombatPhase = CombatPhase.defend;
            }
            else
            {
                CombatPhase = CombatPhase.attack;
            }

            StartCombat(EnemyData.enemyType);
        }
        private void OnCombatEnd()
        {
            var newPlayerData = new PlayerDto();
            newPlayerData.Composture = PlayerData.Composture;
            newPlayerData.Hp = PlayerData.Hp;

            //call event to update player Data
            DataEvents.onUpdatePlayerData.Invoke(newPlayerData);

            StopCombat();
        }
        
    }
}
