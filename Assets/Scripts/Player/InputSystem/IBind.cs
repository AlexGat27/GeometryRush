using UnityEngine;

namespace Player.InputSystem
{
    public interface IBind
    {
        public KeyCode Key { get; }

        public void Invoke();
    }
}