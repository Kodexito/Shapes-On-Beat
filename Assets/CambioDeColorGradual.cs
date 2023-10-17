using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CambioDeColorGradual : MonoBehaviour
{
    public Material material;
    public int i = 0;
    private Color32[] colors = new Color32[]
        {
            new Color32(255, 0, 0, 100), //red
            new Color32(0, 255, 0, 100), //green
            new Color32(0, 0, 255, 100), //blue
        };

    void Start()
    {
        StartCoroutine(Cycle());
    }

    public IEnumerator Cycle()
    {
        while (true)
        {
            for (float interpolant = 0f; interpolant < 1f; interpolant += Time.deltaTime * 2)
            {
                material.SetColor("_UnderlayColor", Color.Lerp(colors[i % colors.Length], colors[(i + 1) % colors.Length], interpolant));
                yield return null;
            }
            i++;
        }
    }
}
