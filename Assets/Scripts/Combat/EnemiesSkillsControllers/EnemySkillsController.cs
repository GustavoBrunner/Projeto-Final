using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Combat
{
    public class EnemySkillsController : MonoBehaviour
    {
        [SerializeField] private List<CircleSkillController> circleSkillControllers 
            = new List<CircleSkillController>();

        [SerializeField] private EnemyTypes Type;

        [SerializeField] private CombatPhase Phase;

        [Header("Tempo que demora para ligar o próximo skill circle")]
        [Range(0f, 20f)]
        [SerializeField] private float Cooldown;

        [SerializeField] private int index = 0;

        [SerializeField] private CircleSkillController actualSkillCircle;

        [SerializeField] private CombatController CombatController;

        private void OnEnable()
        {
            PopulateCircleSckills();
            CombatController = GetComponentInParent<CombatController>();
            if (CombatController != null)
            {

            }
            CombatEvents.onCombatStarted.AddListener(CombatStarted);
            CombatEvents.onCombatFinished.AddListener(StopCombat);
        }
        private void Update()
        {
            
        }
        private void OnDisable()
        {
            CombatEvents.onCombatStarted.RemoveListener(CombatStarted);
            CombatEvents.onCombatFinished.RemoveListener(StopCombat); 
        }

        public void PopulateCircleSckills()
        {
            circleSkillControllers.Clear();
            circleSkillControllers.AddRange(GetComponentsInChildren<CircleSkillController>());
            
            TurnOffAllCircles();
        }
        private void CombatStarted(EnemyTypes type, CombatPhase phase)
        {
            if(this.Type == type && this.Phase == phase)
            {
                actualSkillCircle = circleSkillControllers[0];
                //actualSkillCircle.gameObject.SetActive(true);
                StartCoroutine(CirclesTimer());
            }
        }
        private void StopCombat()
        {
            StopCoroutine(CirclesTimer());
            TurnOffAllCircles();
        }
        private void TurnOffAllCircles()
        {
            foreach (var circle in circleSkillControllers)
            {
                circle.gameObject.SetActive(false);
            }
        }
        IEnumerator CirclesTimer()
        {
            while (this.CombatController.IsCombat)
            {
                Debug.Log("Inside circlesTimer");
                //logic to start the first skill circle
                //get the index of the actual index
                index = circleSkillControllers.IndexOf(actualSkillCircle);
                if (!actualSkillCircle.gameObject.activeSelf)
                {
                    actualSkillCircle.gameObject.SetActive(true);
                }
                index++;
                actualSkillCircle = circleSkillControllers[index % circleSkillControllers.Count];
                yield return new WaitForSeconds(Cooldown);
            }
        }
    }
}