using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class TypeBroker : MonoBehaviour
    {
        public static MouseController MouseInstance = new MouseController();
        public static UiController UiController = new UiController();
    }
}