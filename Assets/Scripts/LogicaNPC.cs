using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public LogicaPersonaje jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMision;
    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "Obtén lo necesario" +
                           "\n Restantes: " + numDeObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("COLLIDER ENTER MISSION");
            jugadorCerca = true;
            if (!aceptarMision)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }

    public void No()
    {
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        foreach (GameObject objetivo in objetivos)
        {
            objetivo.SetActive(true);
        }

        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }

    public void ProcesarAceptacionMision()
    {
        if (aceptarMision && jugador.puedeSaltar)
        {
            print("PRESIONADO X");
            Vector3 posicionJugador = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);
            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }
}
