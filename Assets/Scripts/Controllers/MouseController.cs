using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Combat;
using System;



namespace Game.Controllers
{
    public class MouseController : TypeBroker
    {
        [SerializeField] private PointerEventData PointerEventData;
        [SerializeField] private RaycastResult TestGO;


        private void Awake()
        {
            PointerEventData = new PointerEventData(EventSystem.current);
        }
        private void Update()
        {
            
            if(Input.GetMouseButton(0) && IsMouseOverSkillCircle()) 
            {
                
                Debug.Log($"Skill circle clicked: ");
            }
            if (CheckMouseOverTarget())
            {
                CombatEvents.onTargetHitted.Invoke();
            }
        }

        private bool CheckMouseOverTarget()
        {

            PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(PointerEventData, results);


            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<TargetDummy>() is null)
                {
                    //chama evento que indica ao combat controller que o mouse está sobre um target

                    Debug.Log("Target atingido");
                    results.RemoveAt(i);
                    i--;
                }
            }

            return results.Count > 0;
        }

        private bool IsMouseOverSkillCircle()
        {
            PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(PointerEventData, results);
            

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<UiRaycastIgnoreDummy>() != null)
                {
                    results.RemoveAt(i);
                    i--;
                }
            }
            
            return results.Count > 0;
        } 
        public void Click(GameObject go)
        {
            var circle = go.GetComponent<CircleSkillController>();
            if (circle != null)
            {
                circle.OnCircleClicked();
                Debug.Log($"Skill circle clicked: {go.name}");
            }
            else
            {
                Debug.Log("Objeto nulo");
            }
        }    
    }
}