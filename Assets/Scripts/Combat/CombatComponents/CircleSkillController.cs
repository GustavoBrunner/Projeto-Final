using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class CircleSkillController : MonoBehaviour
    {
        //transform do circulo azul
        [SerializeField] private Transform BlueCircleTf;

        //vector2 que vai diminuir o tamanho do objeto
        [SerializeField] private Vector2 InitialSize = Vector2.one;

        [Header("Quantidade subtra�da do c�rculo azul")]
        [Range(0f, 10f)]
        [SerializeField] private float SubSize;

        //[Range(0f, 10f)]
        //[SerializeField] private float Timer;

        [Header("Tempo que espera at� a pr�xima diminui��o do c�rculo")]
        [Range(0f, 1f)]
        [SerializeField] private float Cooldown;

        [Header("Tamanho m�nimo do c�rculo externo para desaparecer")]
        [Range(0f, 100f)]
        [SerializeField] private float MinSize;

        [Header("O tamanho atual do c�rculo externo")]
        [SerializeField] private float ActualSize;

        private Animator _animator;

        [Header("Velocidade de reprodu��o da anima��o")]
        [SerializeField] private float AnimationSpeed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            this._animator.speed = AnimationSpeed;
        }

        private void OnEnable()
        {
            this.InitialSize = Vector2.one;
            this.BlueCircleTf.localScale = InitialSize;
            
            this.StartCoroutine(StartTimer());
        }

        protected virtual void OnDisable()
        {
            this.StopAllCoroutines();
            ActualSize = 100f;
        }

        IEnumerator StartTimer()
        {
            while(ActualSize > MinSize) 
            {
                ActualSize -= SubSize;
                //Debug.Log(this.BlueCircleTf.localScale);
                if(ActualSize <= MinSize)
                {
                    CombatEvents.onCircleClicked.Invoke(false);
                    this.gameObject.SetActive(false);
                }
                yield return new WaitForSeconds(Cooldown);
            }
        }

        public virtual void OnCircleClicked()
        {
            CheckSize();   
            //Debug.Log($"{this.gameObject.name} desativado");

            this.gameObject.SetActive(false);
        }

        protected void CheckSize()
        {
            if (ActualSize > 70f)
            {
                CombatEvents.onCircleClicked.Invoke(false);
            }
            else
            {
                CombatEvents.onCircleClicked.Invoke(true);
            }
        }
    }
}
