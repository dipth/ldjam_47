using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F1))
        {
            JumpToLvl(1);
        }
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F2))
        {
            JumpToLvl(2);
        }
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F3))
        {
            JumpToLvl(3);
        }
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F4))
        {
            JumpToLvl(4);
        }
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F5))
        {
            JumpToLvl(5);
        }
    }

    private void JumpToLvl(int num)
    {
        //Debug.Log($"Jumping to level {num}...");
        GameManager.instance.NewWaypoint(num - 1);
        GameManager.instance.ResetPlayer();
    }
}
