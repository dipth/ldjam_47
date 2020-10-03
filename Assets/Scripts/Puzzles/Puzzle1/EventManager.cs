using System;
using UnityEngine;

namespace Puzzles
{
    namespace Puzzle1
    {
        public class EventManager : MonoBehaviour
        {
            private static EventManager _instance;

            public static EventManager Instance { get { return _instance; } }

            private void Awake()
            {
                if (_instance != null && _instance != this)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    _instance = this;
                }
            }

            public event Action<GameObject> PressurePlateEnter;
            public event Action<GameObject> PressurePlateExit;

            public void OnPressurePlateEnter(GameObject gameObject)
            {
                Debug.Log("OnPressurePlateEnter triggered");
                PressurePlateEnter?.Invoke(gameObject);
            }

            public void OnPressurePlateExit(GameObject gameObject)
            {
                Debug.Log("OnPressurePlateExit triggered");
                PressurePlateExit?.Invoke(gameObject);
            }
        }
    }
}

