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
                Debug.Log("OpenDoor called");
                if (gameObject.tag == "Player" || gameObject.tag == "Ghost")
                    this.gameObject.SetActive(false);
            }

            private void CloseDoor(GameObject gameObject)
            {
                Debug.Log("CloseDoor called");
                if (gameObject.tag == "Player" || gameObject.tag == "Ghost")
                    this.gameObject.SetActive(true);
            }
        }
    }
}