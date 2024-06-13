
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{

    public class MovementController : MonoBehaviour
    {
        [SerializeField] private bool SmoothTransition;
        [Range(0f, 50f)]
        [SerializeField] private float TransitionSpeed;
        [Range(0f, 200f)]
        [SerializeField] private float TransitionRotationSpeed;
        [SerializeField] private float RunSpeed;

        [SerializeField] private Vector3 TargetGridPos;
        [SerializeField] private Vector3 PrevTargetGridPos;
        [SerializeField] private Vector3 TargetRot;

        private bool _canRun;
        [SerializeField] private PlayerController PlayerController;
        [SerializeField] private CollisionController CollisionController;

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
                    RunSpeed = 4f;
                }
                else
                {
                    RunSpeed = 2f;
                }
                _canRun = value;
            } 
        }
        //unity methods
        private void Start()
        {
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
            if (true)
            {
                PrevTargetGridPos = TargetGridPos;

                Vector3 targetPosition = TargetGridPos;

                if (TargetRot.y > 270 && TargetRot.y < 361) TargetRot.y = 0f;
                if (TargetRot.y < 0f) TargetRot.y = 270f;

                if (!SmoothTransition)
                {
                    transform.position = targetPosition;
                    transform.rotation = Quaternion.Euler(TargetRot);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * TransitionSpeed);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(TargetRot), Time.deltaTime * TransitionRotationSpeed);
                }

            }
            else
            {
                TargetGridPos = PrevTargetGridPos;
            }
        }
        public void RotateRight()
        {
            if(IsAtRest)
            {
                TargetRot += Vector3.up * 90f;
            }
        }
        public void RotateLeft()
        {
            if(IsAtRest)
            {
                TargetRot -= Vector3.up * 90f;
            }
        }
        public void MoveFoward() 
        {
            if (IsAtRest && !CollisionController.FrontCollision) {
                TargetGridPos += transform.forward * RunSpeed;
            }
        }

        public void MoveBack()
        {
            if (IsAtRest && !CollisionController.BackCollision)
            {
                TargetGridPos -= transform.forward * RunSpeed;
            }
        }

        public void MoveLeft()
        {
            if (IsAtRest && !CollisionController.LeftCollision)
            {
                TargetGridPos += transform.right * RunSpeed;
            }
        }
        public void MoveRight()
        {
            if (IsAtRest && !CollisionController.RightCollision)
            {
                TargetGridPos -= transform.right * RunSpeed;
            }
        }

    }
}