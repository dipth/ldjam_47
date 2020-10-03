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
                PuzzleManager.Instance.OnPressurePlateEnter(this.gameObject, other.gameObject);
            }

            private void OnTriggerExit(Collider other)
            {
                PuzzleManager.Instance.OnPressurePlateExit(this.gameObject, other.gameObject);
            }
        }
    }
}