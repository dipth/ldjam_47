using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    private Material material;

    [ColorUsage(true, true)]
    private Color startColor;

    private Color endColor;

    private Color color;

    private float i;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.shader = Shader.Find("Standard");
        startColor = material.color;
        endColor = new Color(startColor.r * 10f, startColor.g*10f, startColor.b * 10f, startColor.a);
    }

    // Update is called once per frame
    void Update()
    {     
        i += Time.deltaTime * 0.5f;

        color = Color.Lerp(startColor, endColor, Mathf.Clamp(Mathf.PingPong(i,1), 0.5f, 1f));

        var intensity = (color.r + color.g + color.b) / 3f;
        var factor = 1f / intensity;       

        var newcolor = new Color(color.r * 100, color.g*100, color.b * 100, color.a);

        material.SetColor("_EmissionColor", newcolor);       
    }
}
