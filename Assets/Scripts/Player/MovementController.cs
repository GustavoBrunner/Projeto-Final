
using Game.TurnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{

    public class MovementController : MonoBehaviour
    {
        

        [SerializeField] private Vector3 TargetGridPos;
        [SerializeField] private Vector3 PrevTargetGridPos;
        [SerializeField] private Vector3 TargetRot;

        private bool _canRun;
        [SerializeField] private PlayerController PlayerController;
        [SerializeField] private CollisionController CollisionController;
        [SerializeField] private PlayerDataController PlayerDataController;

        public bool IsAtRest {
            get 
            {   
                //if not moving neither turning to a position, return true 
                if ((Vector3.Distance(transform.position, TargetGridPos) < 0.05f) &&
                    (Vector3.Distance(transform.eulerAngles, TargetRot)) < 0.05f){
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            set { } 
        }
        
        public bool CanRun {
            get => _canRun;
            set
            {
                if (value)
                {
                    PlayerDataController.Data.RunSpeed = 4f;
                }
                else
                {
                    PlayerDataController.Data.RunSpeed = 2f;
                }
                _canRun = value;
            } 
        }
        //unity methods
        private void Start()
        {
            PlayerDataController = GetComponent<PlayerDataController>();
            this.CollisionController = GetComponent<CollisionController>();
            TargetGridPos = Vector3Int.RoundToInt(transform.position);
            CanRun = false;
        }
        private void LateUpdate()
        {
            Move();
        }

        //methods
        private void Move()
        {
            PrevTargetGridPos = TargetGridPos;

            Vector3 targetPosition = TargetGridPos;

            if (TargetRot.y > 270 && TargetRot.y < 361) TargetRot.y = 0f;
            if (TargetRot.y < 0f) TargetRot.y = 270f;

            if (!PlayerDataController.Data.SmoothTransition)
            {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(TargetRot);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * PlayerDataController.Data.TransitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(TargetRot), Time.deltaTime * PlayerDataController.Data.TransitionRotationSpeed);
            }
        }

        public void RotateRight()
        {
            if(IsAtRest)
            {
                TargetRot += Vector3.up * 90f;
                TurnEvents.PlayerActed.Invoke();
            }
        }
        public void RotateLeft()
        {
            if(IsAtRest)
            {
                TargetRot -= Vector3.up * 90f;
                TurnEvents.PlayerActed.Invoke();
            }
        }
        public void MoveFoward() 
        {
            if (IsAtRest && !CollisionController.FrontCollision) {
                TargetGridPos += transform.forward * PlayerDataController.Data.RunSpeed;
                TurnEvents.PlayerActed.Invoke();
            }
        }

        public void MoveBack()
        {
            if (IsAtRest && !CollisionController.BackCollision)
            {
                TargetGridPos -= transform.forward * PlayerDataController.Data.RunSpeed;
                TurnEvents.PlayerActed.Invoke();
            }
        }

        public void MoveLeft()
        {
            if (IsAtRest && !CollisionController.LeftCollision)
            {
                TargetGridPos += transform.right * PlayerDataController.Data.RunSpeed;
                TurnEvents.PlayerActed.Invoke();
            }
        }
        public void MoveRight()
        {
            if (IsAtRest && !CollisionController.RightCollision)
            {
                TargetGridPos -= transform.right * PlayerDataController.Data.RunSpeed;
                TurnEvents.PlayerActed.Invoke();
            }
        }

    }
}