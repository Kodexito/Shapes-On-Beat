using Kino;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InicioController : MonoBehaviour
{
    public GameObject canvasJuego;
    public AudioClip largo;
    public AudioClip musicaInicio;
    public TMP_Asset txtAsset;
    public Color colorTexto = Color.black;
    private bool glitch = false;
    private int cantLoops = 0;
    public GameObject cuadrado;
    public GameObject circulo;
    public GameObject triangulo;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        txtAsset.material.SetColor("_UnderlayColor", colorTexto);

        if (glitch)
        {
            if (Camera.main.GetComponent<DigitalGlitch>().intensity < 1f)
            {
                Camera.main.GetComponent<AnalogGlitch>().colorDrift += Time.deltaTime * 0.8f;
                Camera.main.GetComponent<AnalogGlitch>().scanLineJitter += Time.deltaTime * 0.8f;
                Camera.main.GetComponent<DigitalGlitch>().intensity += Time.deltaTime / 2.5f;
            }
            else
            {
                Camera.main.GetComponent<DigitalGlitch>().intensity = 1f;
                Camera.main.GetComponent<AnalogGlitch>().colorDrift = 1;
                Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 1;
                gameObject.SetActive(false);
                canvasJuego.SetActive(true);
            }
        }
    }

    public void TodosAcertados()
    {
        if (cuadrado.GetComponent<CuadradoController>().dado && circulo.GetComponent<CirculoController>().dado && triangulo.GetComponent<TrianguloController>().dado)
        {
            glitch = true;
        }
    }

    public void CambioAnim()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<AudioSource>().clip = musicaInicio;
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().Play("InicioAnimParpadeos");
    }

    public void SumaLoop()
    {
        TodosAcertados();
        cantLoops++;
        if (cantLoops == 6)
        {
            cantLoops = 0;
            CambioAnim();
        }
        else if ((cantLoops + 1) % 3 == 0 && cantLoops != 0)
        {
            GetComponent<Animator>().Play("InicioAnimParpadeosFlecha");
        }
        else
        {
            GetComponent<Animator>().Play("InicioAnimParpadeos");
        }
    }

    public void SuenaMusica()
    {
        GetComponent<AudioSource>().Play();
    }
}
