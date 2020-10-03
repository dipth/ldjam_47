using UnityEngine;

namespace Puzzles
{
    namespace Puzzle1
    {
        public class DoorController : MonoBehaviour
        {
            private void Start()
            {
                EventManager.Instance.PressurePlateEnter += OpenDoor;
                EventManager.Instance.PressurePlateExit += CloseDoor;
            }

            private void OpenDoor(GameObject gameObject)
            {
                if (!gameObject.CompareTag("Player") && !gameObject.CompareTag("Ghost"))
                    return;

                Debug.Log("OpenDoor called");
                this.gameObject.SetActive(false);
            }

            private void CloseDoor(GameObject gameObject)
            {
                if (!gameObject.CompareTag("Player") && !gameObject.CompareTag("Ghost"))
                    return;

                Debug.Log("CloseDoor called");
                this.gameObject.SetActive(true);
            }
        }
    }
}