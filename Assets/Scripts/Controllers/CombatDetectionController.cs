using Game.Combat;
using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private List<EnemyDto> EnemyList = new List<EnemyDto>();
        [SerializeField] private PlayerDto PlayerData = new PlayerDto();
        private void Awake()
        {
            PlayerData.Composture = 50;
            PlayerData.Hp = 100;
            PlayerData.Damage = 30;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                
                CombatEvents.onCombatCalled.Invoke(EnemyList, PlayerData);
                EnemyList.Clear();
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                
                CombatEvents.onCombatCalled.Invoke(EnemyList, PlayerData);
                EnemyList.Clear();
            }
        }
    }
}