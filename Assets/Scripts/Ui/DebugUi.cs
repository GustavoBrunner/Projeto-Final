using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



namespace Game.Ui
{
    public class DebugUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text DebugText;

        private void Start()
        {
            DebugText = GetComponentInChildren<TMP_Text>();
            UiEvents<int>.onUiDebug.AddListener(UpdateDebug<int>);
            UiEvents<string>.onUiDebug.AddListener(UpdateDebug<string>);
        }

        private void UpdateDebug<T>(T info)
        {
            var input = info.ToString();
            DebugText.text = input;
        }
    }
}