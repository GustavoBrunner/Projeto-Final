using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [System.Serializable]
    public record PlayerData : Data
    {
        public bool SmoothTransition;
        
        [Range(0f, 200f)]
        public float TransitionRotationSpeed;
        [Range(0f, 1f)]
        public float AttackSpeed;

        public bool CanAttack = true;
        public KeyCode Foward;
        public KeyCode Backward;
        public KeyCode Right;
        public KeyCode Left;
        public KeyCode RotateRight;
        public KeyCode RotateLeft;

        public float RayDistance;
    }
}