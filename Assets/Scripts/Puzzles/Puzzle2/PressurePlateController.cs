using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzles
{
    namespace Puzzle2
    {
        public class PressurePlateController : MonoBehaviour
        {
            private void OnTriggerEnter(Collider other)
            {
                if (other.GetType().Equals(typeof(CharacterController)))
                    return;

                if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ghost"))
                    return;

                PuzzleManager.Instance.OnPressurePlateEnter(this.gameObject, other.gameObject);
            }

            private void OnTriggerExit(Collider other)
            {
                if (other.GetType().Equals(typeof(CharacterController)))
                    return;

                if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ghost"))
                    return;

                PuzzleManager.Instance.OnPressurePlateExit(this.gameObject, other.gameObject);
            }
        }
    }
}