using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{

    public LogicaPersonaje lp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lp.puedeSaltar = true;
    }

    private void OnTriggerStay(Collider other)
    {
        lp.puedeSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        lp.puedeSaltar = false;
    }
}
