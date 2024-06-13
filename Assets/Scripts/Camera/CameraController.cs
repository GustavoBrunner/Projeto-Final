using Game.Combat;
using Game.Objects;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerDataController DataController;
    private RaycastHit hit;

    [SerializeField]private Vector3 screenMousePos;

    [SerializeField] private Camera CurrentCam;

    private void Start()
    {
        DataController = GetComponentInParent<PlayerDataController>();
        CurrentCam = GetComponent<Camera>();
    }
    void Update()
    {
    }
    private void LateUpdate()
    {
        CheckObjectHitted();
    }
    void CheckObjectHitted()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction *1000f, Color.yellow);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            var obj = hit.collider.GetComponent<IInteractable>();
            if (obj is not null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    if((obj as Interactable).CalculateDistance(transform.position))
                    {
                        if(hit.collider.GetComponent<IDamageble>() != null)
                        {
                            Debug.Log("Enemy interacted");
                            var damageble = obj as IDamageble;
                            damageble.TakeDamage(DataController.Data.Damage);
                            return;
                        }
                        Debug.Log("Interactive obj");
                        obj.Interact();
                        return;
                    }
                }
            }
        }
    }
}
