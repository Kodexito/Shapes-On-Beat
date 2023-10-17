using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculoController : MonoBehaviour
{
    private int cuentaClicks = 0;
    public int estadoDeteccion = 0;
    public bool dado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (estadoDeteccion == 2)
        {
            dado = false;
            cuentaClicks = 0;
        }
        else if (estadoDeteccion == 1)
        {
            if (cuentaClicks == 1)
            {
                dado = true;
                Debug.Log("acierto2");
            } else
            {
                dado = true;
                Debug.Log("fallo2");
            }
        }
    }

    private void OnMouseDown()
    {
        if (estadoDeteccion == 0)
        {
            dado = false;
        }
        cuentaClicks++;
    }
}
