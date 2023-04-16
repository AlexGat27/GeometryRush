using UnityEngine;

namespace Player.InputSystem
{
    public interface IInputDevice
    {
        public void PlayAction(KeyCode key);
    }
}