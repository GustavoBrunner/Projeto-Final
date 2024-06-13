using System.Numerics;

namespace Game.Objects
{
    public interface IInteractable 
    {
        UnityEngine.Vector3 Vector3 { get; }
        void Interact();

    }
}