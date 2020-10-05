using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool canTakeInput;

    private void Update()
    {
        if (canTakeInput)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(StartGame());
                canTakeInput = false;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(Quitgame());
                canTakeInput = false;
            }
        }
    }

    IEnumerator StartGame() 
    {
        text.text = text.text.Remove(text.text.Length - 1);
        text.text += " y_";
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
    
    IEnumerator Quitgame() 
    {
        text.text = text.text.Remove(text.text.Length - 1);
        text.text += " n_";
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
