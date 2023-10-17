using Kino;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JuegoController : MonoBehaviour
{

    private bool juegoEmpezado = false;
    public AudioSource glitchSonido;
    public List<AudioClip> clipsMusica;
    private int numCancion = 0;
    public GameObject textoJuego;

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
            glitchSonido.volume = Camera.main.GetComponent<DigitalGlitch>().intensity / 10;
        }
        else if (!juegoEmpezado)
        {
            glitchSonido.Stop();
            juegoEmpezado = true;
        }

        if (juegoEmpezado)
        {
            if (!GetComponent<AudioSource>().isPlaying && !textoJuego.activeInHierarchy)
            {
                StartCoroutine(SpeedUp());
            }
        }
    }

    private IEnumerator SpeedUp()
    {
        if (numCancion == 0)
        {
            textoJuego.GetComponent<TMP_Text>().text = "START";
        }
        else if (numCancion < 14)
        {
            textoJuego.GetComponent<TMP_Text>().text = "SPEED UP";
        }
        textoJuego.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        textoJuego.SetActive(false);
        GetComponent<AudioSource>().clip = clipsMusica[numCancion];
        GetComponent<AudioSource>().Play();
        numCancion++;
    }
}
