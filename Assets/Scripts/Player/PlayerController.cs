using Game.TurnSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Game.Player
{
    [RequireComponent(typeof(CollisionController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerDataController PlayerDataController;

        private void Awake()
        {
            this.PlayerDataController = GetComponent<PlayerDataController>();
        }
        private void Update()
        {
            
        }

        IEnumerator AttackCooldown()
        {
            TurnEvents.PlayerActed.Invoke();
            PlayerDataController.Data.CanAttack = false;
            yield return new WaitForSeconds(PlayerDataController.Data.AttackSpeed);
            PlayerDataController.Data.CanAttack = true; 
        }
        public void Attack()
        {
            if (PlayerDataController.Data.CanAttack)
            {
                StartCoroutine(AttackCooldown());
            }
        }
    }
}