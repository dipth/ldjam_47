using UnityEngine;

namespace Puzzles
{
    namespace Puzzle1
    {
        public class PuzzleManager : MonoBehaviour
        {
            private static PuzzleManager _instance;

            public static PuzzleManager Instance { get { return _instance; } }

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

            public GameObject pressurePlate;
            public GameObject door;

            private int pressurePlateWeight = 0;

            public void OnPressurePlateEnter(GameObject pressurePlate, GameObject triggerPerson)
            {
                //Debug.Log("OnPressurePlateEnter called");

                if (pressurePlate == this.pressurePlate)
                    pressurePlateWeight++;

                UpdateDoor();
            }

            public void OnPressurePlateExit(GameObject pressurePlate, GameObject triggerPerson)
            {
                //Debug.Log("OnPressurePlateExit called");

                if (pressurePlate == this.pressurePlate)
                    pressurePlateWeight--;

                UpdateDoor();
            }

            private void UpdateDoor()
            {
                //Debug.Log($"UpdateDoor called: {pressurePlateWeight}");

                if (pressurePlateWeight > 0)
                {
                    OpenDoor();
                }
                else
                {
                    CloseDoor();
                }
            }

            private void OpenDoor()
            {
                //Debug.Log("OpenDoor called");

                var doorManager = door.GetComponent(typeof(DoorManager)) as DoorManager;
                doorManager.OpenDoor();

               // door.SetActive(false);
            }

            private void CloseDoor()
            {
                //Debug.Log("CloseDoor called");

                 var doorManager = door.GetComponent(typeof(DoorManager)) as DoorManager;
                doorManager.CloseDoor();

              //  door.SetActive(true);
            }
        }

    }
}
