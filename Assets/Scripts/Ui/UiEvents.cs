using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Game.Ui
{
    public class UiDebug<T> : UnityEvent<T> { }
    public class UiEvents<T> 
    {
        public static readonly UiDebug<T> onUiDebug = new UiDebug<T>();
        //public static readonly UiDebug onUiDebug = new UiDebug();
    }
}