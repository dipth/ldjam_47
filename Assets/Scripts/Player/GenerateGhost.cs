using UnityEngine;

public class GenerateGhost : MonoBehaviour
{
    public Ghost ghostPrefab;
    public Transform ghostParent;
    TimeController timeController;

    private void Awake()
    {
        timeController = GetComponent<TimeController>();
        timeController.OnTimeRewind += CreateGhost;
    }

    public void CreateGhost() 
    {
        Ghost clone;
        clone = Instantiate(ghostPrefab, transform.position, Quaternion.identity,ghostParent);
        clone.AddPath(timeController.points);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            CreateGhost();
        }
    }
}
