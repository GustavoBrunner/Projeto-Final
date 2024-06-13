using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data{

    [System.Serializable]
    public record Data
    {
        public int Hp;
        public int Damage;
        public float RunSpeed;
        [Range(0f, 50f)]
        public float TransitionSpeed;

        public Data(int hp, int damage, float runSpeed, float transactionSpeed)
        {
            Hp = hp;
            Damage = damage;
            RunSpeed = runSpeed;
            TransitionSpeed = transactionSpeed;
        }
        public Data() { }
    }

}