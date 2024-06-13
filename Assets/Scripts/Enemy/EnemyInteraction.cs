using Game.Combat;
using Game.Objects;
using Game.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyInteraction : Interactable, IDamageble
    {
        [SerializeField] private int _Damage;
        public int Damage { get => _Damage; set => _Damage = value; }


        public void TakeDamage(int damage)
        {
            UiEvents<string>.onUiDebug.Invoke($"Enemy clicked, {damage} damage done");
        }
    }
}