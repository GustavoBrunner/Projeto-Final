using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.TurnSystem
{
    public class TurnSystemControll : MonoBehaviour
    {
        [SerializeField] private bool EnemiesCanAct;

        [Range(0f, 1f)]
        [SerializeField] private float Cooldown;

        private void Awake()
        {
            TurnEvents.PlayerActed.AddListener(StartActCooldown);
        }


        IEnumerator ActCooldown()
        {
            EnemiesCanAct = true;
            yield return new WaitForSeconds(Cooldown);
            EnemiesCanAct = false;
            StopCoroutine(ActCooldown());
        }
        void StartActCooldown()
        {
            StartCoroutine(ActCooldown());
        }


    }
}