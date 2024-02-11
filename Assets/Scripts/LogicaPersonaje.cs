using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    [FormerlySerializedAs("velocidadCorriendo")] public float velocidadMovimientoCorriendo = 10.0f;

    public float velocidadRotacion = 200.0f;

    public Rigidbody rb;

    public float fuerzaSalto = 8f;

    public bool puedeSaltar = true;
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = .6f;

    public float velocidadInicial;
    public float velocidadAgachado;

    public LogicaNPC npcMision;
    
    public Animator anim;

    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadInicial * 0.5f;
    }

    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0,x * Time.deltaTime * velocidadRotacion, 0);
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? velocidadMovimientoCorriendo : velocidadMovimiento;
            transform.Translate(0, 0, y * Time.deltaTime * currentSpeed);
        }
        
        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && puedeSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            print("Deberia iniciar misión");
            npcMision.aceptarMision = true;
            npcMision.ProcesarAceptacionMision();
        }

        if (!estoyAtacando)
        {
            anim.SetBool("golpeo",false);
        }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);

        if (puedeSaltar)
        {
            if (!estoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("haSaltado",true);
                    rb.AddForce(new Vector3(0,fuerzaSalto,0),ForceMode.Impulse);
                }
                anim.SetBool("tocaSuelo",true);
                anim.SetBool("haSaltado",false);
                
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("agachado",true);
                    velocidadMovimiento = velocidadAgachado;
                }
                else
                {
                    anim.SetBool("agachado",false);
                    velocidadMovimiento = velocidadInicial;
                }
            }
            
        }
        else
        {
            EstaCayendo();
        }

        
        
    }

    void EstaCayendo()
    {
        anim.SetBool("tocaSuelo",false);
        anim.SetBool("haSaltado",false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}
