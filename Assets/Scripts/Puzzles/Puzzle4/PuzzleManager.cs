using UnityEngine;

namespace Puzzles
{
    namespace Puzzle4
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

            public GameObject pressurePlate1;
            public GameObject door1;
            public GameObject pressurePlate2;
            public GameObject door2;
            public GameObject pressurePlate3;
            public GameObject door3;
            public GameObject pressurePlate4;
            public GameObject door4;

            private int pressurePlate1Weight = 0;
            private int pressurePlate2Weight = 0;
            private int pressurePlate3Weight = 0;
            private int pressurePlate4Weight = 0;

            public void OnPressurePlateEnter(GameObject pressurePlate, GameObject triggerPerson)
            {
                Debug.Log("OnPressurePlateEnter called");

                if (pressurePlate == pressurePlate1)
                {
                    pressurePlate1Weight++;
                }
                else if (pressurePlate == pressurePlate2)
                {
                    pressurePlate2Weight++;
                }
                else if (pressurePlate == pressurePlate3)
                {
                    pressurePlate3Weight++;
                }
                else if (pressurePlate == pressurePlate4)
                {
                    pressurePlate4Weight++;
                }

                UpdateDoors();
            }

            public void OnPressurePlateExit(GameObject pressurePlate, GameObject triggerPerson)
            {
                Debug.Log("OnPressurePlateEnter called");

                if (pressurePlate == pressurePlate1)
                {
                    pressurePlate1Weight--;
                }
                else if (pressurePlate == pressurePlate2)
                {
                    pressurePlate2Weight--;
                }
                else if (pressurePlate == pressurePlate3)
                {
                    pressurePlate3Weight--;
                }
                else if (pressurePlate == pressurePlate4)
                {
                    pressurePlate4Weight--;
                }

                UpdateDoors();
            }

            private void UpdateDoors()
            {
                Debug.Log($"UpdateDoor called: {pressurePlate1Weight}, {pressurePlate2Weight}, {pressurePlate3Weight}, {pressurePlate4Weight}");

                if (pressurePlate1Weight > 0)
                {
                    OpenDoor(door1);
                } else
                {
                    CloseDoor(door1);
                }

                if (pressurePlate2Weight > 0)
                {
                    OpenDoor(door2);
                }
                else
                {
                    CloseDoor(door2);
                }

                if (pressurePlate3Weight > 0)
                {
                    OpenDoor(door3);
                }
                else
                {
                    CloseDoor(door3);
                }

                if (pressurePlate4Weight > 0)
                {
                    OpenDoor(door4);
                }
                else
                {
                    CloseDoor(door4);
                }
            }

            private void OpenDoor(GameObject door)
            {
                Debug.Log("OpenDoor called");

                var doorManager = door.GetComponent(typeof(DoorManager)) as DoorManager;
                doorManager.OpenDoor();

               // door.SetActive(false);
            }

            private void CloseDoor(GameObject door)
            {
                Debug.Log("CloseDoor called");

                var doorManager = door.GetComponent(typeof(DoorManager)) as DoorManager;
                doorManager.CloseDoor();

              //  door.SetActive(true);
            }
        }  
    }
}
