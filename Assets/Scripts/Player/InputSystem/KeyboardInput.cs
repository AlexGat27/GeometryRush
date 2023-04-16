using UnityEngine;
using System.Collections.Generic;

namespace Player.InputSystem
{
    public sealed class KeyboardInput : MonoBehaviour, IInputDevice
    {
        [SerializeField] private KeyboardBind[] _binds;

        private Dictionary<KeyCode, List<KeyboardBind>> _bindsDictionary;

        private void Awake()
        {
            LoadBinds();
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                foreach (var bind in _binds)
                {
                    if (Input.GetKeyDown(bind.Key) && _bindsDictionary.ContainsKey(bind.Key))
                    {
                        PlayAction(bind.Key);
                    }
                }
            }
        }

        private void LoadBinds()
        {
            _bindsDictionary = new Dictionary<KeyCode, List<KeyboardBind>>();

            foreach (var bind in _binds)
            {
                if (!_bindsDictionary.ContainsKey(bind.Key))
                {
                    _bindsDictionary.Add(bind.Key, new List<KeyboardBind> { bind });
                }
                else
                {
                    _bindsDictionary[bind.Key].Add(bind);
                }
            }
        }

        public void PlayAction(KeyCode key)
        {
            if (!_bindsDictionary.ContainsKey(key))
                return;

            List<KeyboardBind> binds = _bindsDictionary[key];

            foreach (var bind in binds)
            {
                bind.Invoke();
            }
        }
    }
}