using UnityEngine;

namespace Puzzles
{
    namespace Puzzle1
    {
        public class PressurePlateController : MonoBehaviour
        {
            private void OnTriggerEnter(Collider other)
            {
                EventManager.Instance.OnPressurePlateEnter(other.gameObject);
            }

            private void OnTriggerExit(Collider other)
            {
                EventManager.Instance.OnPressurePlateExit(other.gameObject);
            }
        }
    }
}