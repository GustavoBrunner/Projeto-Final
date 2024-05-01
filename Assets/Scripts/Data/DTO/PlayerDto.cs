using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [System.Serializable]
    public struct PlayerDto 
    {
        public float Composture;
        public float Hp;
        public float Damage;

        public PlayerDto(float composture, float hp, float damage)
        {
            Composture = composture;
            Hp = hp;
            Damage = damage;
        }
    }
}
