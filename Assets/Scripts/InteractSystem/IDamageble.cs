using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public interface IDamageble
    {
        int Damage { get; set; }
        void TakeDamage(int damage);
    }
}