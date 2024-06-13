using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(MovementController))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyCode Foward;
        [SerializeField] private KeyCode Backward;
        [SerializeField] private KeyCode Right;
        [SerializeField] private KeyCode Left;
        [SerializeField] private KeyCode RotateRight;
        [SerializeField] private KeyCode RotateLeft;

        [SerializeField] MovementController MovementController;

        private void Awake()
        {
            MovementController = GetComponent<MovementController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(Foward)) MovementController.MoveFoward();
            if (Input.GetKeyDown(Backward)) MovementController.MoveBack();
            if (Input.GetKeyUp(Right)) MovementController.MoveRight();
            if (Input.GetKeyUp(Left)) MovementController.MoveLeft();
            if (Input.GetKeyUp(RotateLeft)) MovementController.RotateLeft();
            if (Input.GetKeyUp(RotateRight)) MovementController.RotateRight();
        }
    }

}