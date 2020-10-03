using UnityEngine;

namespace Puzzles
{
    namespace Puzzle1
    {
        public class PressurePlateController : MonoBehaviour
        {
            private void OnTriggerEnter(Collider other)
            {
                if (other.GetType().Equals(typeof(CharacterController)))
                    return;

                if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ghost"))
                    return;

                EventManager.Instance.OnPressurePlateEnter(other.gameObject);
            }

            private void OnTriggerExit(Collider other)
            {
                if (other.GetType().Equals(typeof(CharacterController)))
                    return;

                if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ghost"))
                    return;

                EventManager.Instance.OnPressurePlateExit(other.gameObject);
            }
        }
    }
}