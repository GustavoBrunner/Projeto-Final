using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [System.Serializable]
    public struct EnemyDto 
    {
        public float Composture;
        public float Hp;
        public float Damage;
        public EnemyTypes enemyType;

        public EnemyDto(float composture, float hp, float damage, EnemyTypes enemyType)
        {
            Composture = composture;
            Hp = hp;
            Damage = damage;
            this.enemyType = enemyType;
        }
    }
}