using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class CollisionController : MonoBehaviour
    {
        [SerializeField] private RaycastHit RayFront, RayBack, RayRight, RayLeft;
        public bool FrontCollision, BackCollision, LeftCollision, RightCollision;

        [SerializeField] private PlayerDataController PlayerDataController;
        private void Awake()
        {
            this.PlayerDataController = GetComponent<PlayerDataController>();
        }

        private void FixedUpdate()
        {
            FrontCollision = Physics.Raycast(this.transform.position, transform.forward, out RayFront, PlayerDataController.Data.RayDistance);

            BackCollision = Physics.Raycast(this.transform.position, -transform.forward, out RayBack, PlayerDataController.Data.RayDistance);

            LeftCollision = Physics.Raycast(this.transform.position, -transform.right, out RayLeft, PlayerDataController.Data.RayDistance);

            RightCollision = Physics.Raycast(this.transform.position, transform.right, out RayRight, PlayerDataController.Data.RayDistance);
                    
            Debug.DrawRay(this.transform.position, transform.forward * PlayerDataController.Data.RayDistance,
                Color.green, PlayerDataController.Data.RayDistance);
            Debug.DrawRay(this.transform.position, -transform.forward * PlayerDataController.Data.RayDistance, 
                Color.green, PlayerDataController.Data.RayDistance);
            Debug.DrawRay(this.transform.position, transform.right * PlayerDataController.Data.RayDistance, 
                Color.green, PlayerDataController.Data.RayDistance);
            Debug.DrawRay(this.transform.position, -transform.right * PlayerDataController.Data.RayDistance, 
                Color.green, PlayerDataController.Data.RayDistance);


        }
    }
}