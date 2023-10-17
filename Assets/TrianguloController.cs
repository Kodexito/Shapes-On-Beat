using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloController : MonoBehaviour
{

    private int cuentaClicks = 0;
    public int estadoDeteccion = 0;
    public bool dado = false;
    private Vector3 posMouse1;

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
            if (Input.GetMouseButtonUp(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > posMouse1.y && cuentaClicks == 1)
            {
                dado = true;
                Debug.Log("acertado3");
            } else if (cuentaClicks != 1 || Camera.main.ScreenToWorldPoint(Input.mousePosition).y < posMouse1.y)
            {
                dado = false;
                Debug.Log("fallo3");
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
        posMouse1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

