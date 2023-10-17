using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadradoController : MonoBehaviour
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
            cuentaClicks = 0;
        }
        else if (estadoDeteccion == 1)
        {
            if (cuentaClicks == 2)
            {
                dado = true;
                Debug.Log("acierto1");
            } else
            {
                dado = false;
                Debug.Log("fallo1");
            }
        }
        else if (estadoDeteccion == 4)
        {
            dado = false;
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
