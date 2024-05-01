using Game.Combat;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Combat
{
    public class SpecialSkillCircleController : CircleSkillController
    {
        [SerializeField] private GameObject Target;
        [SerializeField] private bool isMouseClicked;
        private Animator _animator;
        private AnimationClip _animationClip;

        private void Awake()
        {
            CombatEvents.onTargetHitted.AddListener(TargetHitted);
        }
        public void OnMouseLeft()
        {
            if(isMouseClicked)
            {
                this.gameObject.SetActive(false);
                CombatEvents.onCircleClicked.Invoke(false);
            }
        }
        public void OnMouseUp()
        {
            this.isMouseClicked = false;
            StopCoroutine(ShowTarget());
            this.Target.SetActive(false);
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            this.Target.SetActive(false);
        }
        IEnumerator ShowTarget()
        {
            while(isMouseClicked)
            {
                this.Target.SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
            //this.Target.SetActive(false);
        }

        public override void OnCircleClicked()
        {
            isMouseClicked = true;
            Debug.Log("MouseEntered");
            StartCoroutine(ShowTarget());
        }

        private void TargetHitted()
        {
            CheckSize();
            this.gameObject.SetActive(false);
        }

        /*Pendências:
         *Fazer com que o combat controller adicione as sequências dependendo do que combate
         *Fazer com que os valores sejam enviados para a Ui
         *Fazer o reconhecimento das fases de ataque ou defesa, seja no início do combate, ou
         *quando a postura chegar a 0
         */
    }
}