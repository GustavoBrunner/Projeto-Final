using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(MovementController))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerDataController PlayerDataController;

        [SerializeField] MovementController MovementController;
        [SerializeField] PlayerController PlayerController;

        private void Awake()
        {
            PlayerDataController = GetComponent<PlayerDataController>();
            MovementController = GetComponent<MovementController>();
            PlayerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(PlayerDataController.Data.Foward)) MovementController.MoveFoward();
            if (Input.GetKeyDown(PlayerDataController.Data.Backward)) MovementController.MoveBack();
            if (Input.GetKeyUp(PlayerDataController.Data.Right)) MovementController.MoveRight();
            if (Input.GetKeyUp(PlayerDataController.Data.Left)) MovementController.MoveLeft();
            if (Input.GetKeyUp(PlayerDataController.Data.RotateLeft)) MovementController.RotateLeft();
            if (Input.GetKeyUp(PlayerDataController.Data.RotateRight)) MovementController.RotateRight();
            if (Input.GetMouseButtonDown(0)) PlayerController.Attack();
        }
    }

}