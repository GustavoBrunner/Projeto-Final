using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class CollisionController : MonoBehaviour
    {
        [SerializeField] private RaycastHit RayFront, RayBack, RayRight, RayLeft;
        public bool FrontCollision, BackCollision, LeftCollision, RightCollision;

        [SerializeField] private float RayDistance;

        private void FixedUpdate()
        {
            FrontCollision = Physics.Raycast(this.transform.position, transform.forward, out RayFront, RayDistance);

            BackCollision = Physics.Raycast(this.transform.position, -transform.forward, out RayBack, RayDistance);

            LeftCollision = Physics.Raycast(this.transform.position, -transform.right, out RayLeft, RayDistance);

            RightCollision = Physics.Raycast(this.transform.position, transform.right, out RayRight, RayDistance);
                    
            Debug.DrawRay(this.transform.position, transform.forward * RayDistance, Color.green, RayDistance);
            Debug.DrawRay(this.transform.position, -transform.forward * RayDistance, Color.green, RayDistance);
            Debug.DrawRay(this.transform.position, transform.right * RayDistance, Color.green, RayDistance);
            Debug.DrawRay(this.transform.position, -transform.right * RayDistance, Color.green, RayDistance);


        }
    }
}