using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoController : MonoBehaviour
{

    private bool juegoEmpezado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<DigitalGlitch>().intensity > 0)
        {
            Camera.main.GetComponent<AnalogGlitch>().colorDrift -= Time.deltaTime / 1.5f;
            Camera.main.GetComponent<AnalogGlitch>().scanLineJitter -= Time.deltaTime / 1.5f;
            Camera.main.GetComponent<DigitalGlitch>().intensity -= Time.deltaTime / 1.5f;
        }
        else
        {
            juegoEmpezado = true;
        }

        if (juegoEmpezado)
        {

        }
    }
}
