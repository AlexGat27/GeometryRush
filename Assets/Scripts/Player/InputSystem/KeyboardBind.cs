using UnityEngine;
using UnityEngine.Events;
using System;

namespace Player.InputSystem
{
    [Serializable]
    public sealed class KeyboardBind: IBind
    {
        [SerializeField] private KeyCode _key;

        public KeyboardBind(KeyCode key)
        {
            _key = key;
        }

        public KeyCode Key { get { return _key; } }

        public UnityEvent OnKeyDown;

        public void Invoke()
        {
            OnKeyDown?.Invoke();
        }
    }
}