using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private bool isOpen = false;

    private bool isRunning = false;

    IEnumerator[] handleDoor;

    List<GameObject> doorParts;

    Coroutine coroutine;

    int childCount = 0;

    BoxCollider doorCollider;

    int doorDoneCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<BoxCollider>();

        var rotationRoot = transform.GetChild(0).gameObject;
        childCount = rotationRoot.transform.childCount;

        doorParts = new List<GameObject>();
        handleDoor = new IEnumerator[childCount];

        for (int i = 0; i < childCount; i++)
        {

            var doorGameObject = rotationRoot.transform.GetChild(i).gameObject;
            var start = gameObject.transform.position;
            var end = gameObject.transform.position + new Vector3(0, -10, 0);

            handleDoor[i] = HandleDoor(i, doorGameObject, start, end);
            doorParts.Add(doorGameObject);

        }

    }

    /*  IEnumerator OpenDoorCoroutine() {

            for (var i = 0; i < childCount; i++) {
                 yield return new WaitForSeconds(0.2f);



            }
      }*/

    public void OpenDoor()
    {
        for (var i = 0; i < childCount; i++)
        {
            if (handleDoor[i] != null)
                StopCoroutine(handleDoor[i]);
        }

        if (coroutine != null)
            StopCoroutine(coroutine);

        isOpen = true;
        coroutine = StartCoroutine(StartMovement());
    }

    public void CloseDoor()
    {
        for (var i = 0; i < childCount; i++)
        {
            if (handleDoor[i] != null)
                StopCoroutine(handleDoor[i]);
        }

        if (coroutine != null)
            StopCoroutine(coroutine);

        isOpen = false;
        coroutine = StartCoroutine(StartMovement());

    }

    public IEnumerator StartMovement()
    {      
        if (isOpen)
        {
            for (var i = 0; i < childCount; i++)
            {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(handleDoor[i]);
            }

            yield return new WaitForSeconds(0.6f);
            doorCollider.enabled = false;
        }
        else
        {
            doorCollider.enabled = true;

            for (var i = childCount - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(handleDoor[i]);
            }
        }

        yield return null;

    }
    private IEnumerator HandleDoor(int index, GameObject gameObject, Vector3 start, Vector3 end)
    {
        while (true)
        {
            if (isOpen)
            {                           
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, end, Time.deltaTime * 3f);
            }
            else
            {                   
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, start, Time.deltaTime * 3f);
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
