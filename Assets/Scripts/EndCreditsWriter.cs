using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCreditsWriter : MonoBehaviour
{
    public float blinkSpeed = 1f; // in seconds
    public float writeSpeed = 0.05f;  // in seconds
    public float initialWait = 3f;
    public float waitSpeed = 0.5f;

    private TextMeshProUGUI textMesh;
    private bool showingCarret = false;
    private bool writing = false;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
        StartCoroutine(Execute());
    }

    IEnumerator Blink()
    {
        while(true)
        {
            Debug.Log("loop");

            if (showingCarret)
            {
                HideCarret();
            } else
            {
                ShowCarret();
            }

            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    private void ShowCarret()
    {
        Debug.Log("ShowCarret()");

        if (writing || showingCarret)
            return;

        textMesh.text += "_";
        this.showingCarret = true;
    }

    private void HideCarret()
    {
        Debug.Log("HideCarret()");

        if (!showingCarret || textMesh.text == "")
            return;

        if (textMesh.text.Substring(textMesh.text.Length - 1) != "_")
            return;

        textMesh.text = textMesh.text.Remove(textMesh.text.Length - 1);
        this.showingCarret = false;
    }

    private void ClearScreen()
    {
        textMesh.text = "";
    }

    IEnumerator WriteLine(string line)
    {
        writing = true;
        HideCarret();

        foreach (char c in line)
        {
            textMesh.text += c;
            yield return new WaitForSeconds(writeSpeed);
        }

        writing = false;
    }

    IEnumerator Execute()
    {
        float defaultWriteSpeed = writeSpeed;
        yield return new WaitForSeconds(initialWait);

        StartCoroutine(WriteLine("Rebooting...................................\n"));
        while(writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }

        yield return new WaitForSeconds(2f);
        ClearScreen();
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.01f;
        StartCoroutine(WriteLine("  _____ _    _          ___  ____  \n | ____| | _| | _____  / _ \\/ ___| \n |  _| | |/ / |/ / _ \\| | | \\___ \\ \n | |___|   <|   < (_) | |_| |___) |\n |_____|_|\\_\\_|\\_\\___/ \\___/|____/ \n"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("login:"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.3f;
        StartCoroutine(WriteLine("punching_pandas\n"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("password:"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(0.6f);

        writeSpeed = 0.3f;
        StartCoroutine(WriteLine("***************\n"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(2f);

        ClearScreen();
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("> "));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }

        writeSpeed = 0.3f;
        yield return new WaitForSeconds(2f);
        StartCoroutine(WriteLine("users"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(0.5f);

        ClearScreen();
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("Loading user records"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.2f;
        StartCoroutine(WriteLine("....................\n"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        ClearScreen();

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine(" - @Zpanzer: art\n - @TC: art\n - @Santino: art\n - @PierreNS: programming\n - @dipth: programming\n - @BonBonCul: programming\n\n> "));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }

        writeSpeed = 0.3f;
        yield return new WaitForSeconds(2f);
        StartCoroutine(WriteLine("purge"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(0.5f);

        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("\nPurging memory"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.2f;
        StartCoroutine(WriteLine("....................OK"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("\nResetting call stack"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.2f;
        StartCoroutine(WriteLine("..............OK"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.05f;
        StartCoroutine(WriteLine("\nShutting down"));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        writeSpeed = 0.2f;
        StartCoroutine(WriteLine("......................."));
        while (writing)
        {
            yield return new WaitForSeconds(waitSpeed);
        }
        yield return new WaitForSeconds(2f);
        ClearScreen();
    }
}
