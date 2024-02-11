using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class LogicaObjetivos : MonoBehaviour
{
    public int numObjetivos;
    public TextMeshProUGUI textomision;
    public GameObject botonDeMision;
    public GameObject panel;

    public GameObject[] objetosAAgregar;
    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textomision.text = "Recoge las llaves\n" +
                           "Restantes: " + numObjetivos;
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objetivo"))
        {
            Destroy(other.transform.parent.gameObject);
            numObjetivos--;
            print("Entrado en objetivo");
            textomision.text = "Recoge las llaves\n" +
                               "Restantes: " + numObjetivos;
            if (numObjetivos <= 0)
            {
                textomision.text = "Misión completada. \n" +
                                   "Ya puedes avanzar.";
                botonDeMision.SetActive(true);
            }
        }
    }

}
