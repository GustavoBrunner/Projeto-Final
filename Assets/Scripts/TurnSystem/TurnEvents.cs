using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TurnSystem
{
    public class PlayerMoved : UnityEvent { }


    public class TurnEvents 
    {
        public static PlayerMoved PlayerActed = new PlayerMoved();
    }
}