using UnityEngine;

namespace Puzzles
{
    namespace FinalRoom
    {
        public class PressurePlateController : MonoBehaviour
        {
            private void OnTriggerEnter(Collider other)
            {
                if (other.GetType().Equals(typeof(CharacterController)))
                    return;

                if (!other.gameObject.CompareTag("Player"))
                    return;

                PuzzleManager.Instance.OnPressurePlateEnter(this.gameObject, other.gameObject);
            }
        }
    }
}