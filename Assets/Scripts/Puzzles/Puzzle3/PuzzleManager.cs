using UnityEngine;

namespace Puzzles
{
    namespace Puzzle3
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

            public GameObject pressurePlateTopLeft;
            public GameObject pressurePlateTopRight;
            public GameObject pressurePlateBottomLeft;
            public GameObject pressurePlateBottomRight;
            public GameObject door;

            private int pressurePlateTopLeftWeight = 0;
            private int pressurePlateTopRightWeight = 0;
            private int pressurePlateBottomLeftWeight = 0;
            private int pressurePlateBottomRightWeight = 0;

            public void OnPressurePlateEnter(GameObject pressurePlate, GameObject triggerPerson)
            {
                Debug.Log("OnPressurePlateEnter called");

                if (pressurePlate == pressurePlateTopLeft)
                {
                    pressurePlateTopLeftWeight++;
                }
                else if (pressurePlate == pressurePlateTopRight)
                {
                    pressurePlateTopRightWeight++;
                }
                else if (pressurePlate == pressurePlateBottomLeft)
                {
                    pressurePlateBottomLeftWeight++;
                }
                else if (pressurePlate == pressurePlateBottomRight)
                {
                    pressurePlateBottomRightWeight++;
                }

                UpdateDoor();
            }

            public void OnPressurePlateExit(GameObject pressurePlate, GameObject triggerPerson)
            {
                Debug.Log("OnPressurePlateExit called");

                if (pressurePlate == pressurePlateTopLeft)
                {
                    pressurePlateTopLeftWeight--;
                }
                else if (pressurePlate == pressurePlateTopRight)
                {
                    pressurePlateTopRightWeight--;
                }
                else if (pressurePlate == pressurePlateBottomLeft)
                {
                    pressurePlateBottomLeftWeight--;
                }
                else if (pressurePlate == pressurePlateBottomRight)
                {
                    pressurePlateBottomRightWeight--;
                }

                UpdateDoor();
            }

            private void UpdateDoor()
            {
                Debug.Log($"UpdateDoor called: {pressurePlateTopLeftWeight}, {pressurePlateTopRightWeight}, {pressurePlateBottomLeftWeight}, {pressurePlateBottomRightWeight}");

                if (pressurePlateTopLeftWeight > 0 && pressurePlateTopRightWeight > 0 && pressurePlateBottomLeftWeight > 0 && pressurePlateBottomRightWeight > 0)
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
                Debug.Log("OpenDoor called");

                door.SetActive(false);
            }

            private void CloseDoor()
            {
                Debug.Log("CloseDoor called");

                door.SetActive(true);
            }
        }

    }
}
