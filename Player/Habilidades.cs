using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public int ElementoActivo = 0;
    //Dash
    public float DashSpeed;
    public float dashTime;
    public float NumeroDashes;
    //Propulsor
    public float propulsion;
    public int gasolina;
    //Curacion
    public int numerocuraciones;
    public int vidasumada = 30;
    public bool dashobj = true;

    //DashRecharge
    public bool SumarSegundos = true;
    public float Segundos = 0;
    public Rigidbody rb;
    // Sonido
    public GameObject sonidodash;
    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        DashSpeed = 40f;
        dashTime = 0.55f;
        NumeroDashes = 3f;
        gasolina = 1500;
        propulsion = 5f;
        rb = GetComponent<Rigidbody>();
    }



    public void CambiarElemento(int Elemento)
    {
        ElementoActivo = 0;
        ElementoActivo += Elemento;

    }
    // Update is called once per frame
    void Update()
    {

     
        if (NumeroDashes > 0)
        {
            if (Input.GetMouseButtonDown(1))//Dash
            {
                Instantiate(sonidodash, jugador.transform.position, Quaternion.identity);
                dashobj = true;
                StartCoroutine(Dashdetectobj());
                //Debug.Log("numcoruttina");
                if (dashobj == true)
                {
                   
                    StartCoroutine(Dashproceso());
                }
                    NumeroDashes -= 1;

            }
        }

        
 


        if (NumeroDashes <= 2)
        {
            if (SumarSegundos == true)
            {
                StartCoroutine(SumarSegundo());
                SumarSegundos = false;
            }

        }
        if (NumeroDashes <= 2)
        {
            if (Segundos == 3)
            {
                NumeroDashes = NumeroDashes + 1;
                Segundos = Segundos - 3;
            }

        }



    }
    IEnumerator Dashproceso()
    {

        float startTime = Time.time;
        if (dashobj == true)
        {

            while (Time.time < startTime + dashTime)
            {
                transform.Translate(transform.forward * DashSpeed * Time.deltaTime, Space.World);
                yield return null;
            }

           

        }

    }

    IEnumerator SumarSegundo()
    {

        Segundos = Segundos + 1;
        yield return new WaitForSeconds(1f);
        SumarSegundos = true;
    }
    IEnumerator Dashdetectobj()
    {
        float startTime = Time.time;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 40f))
        {
            Debug.Log("lo");
            
            

            while (Time.time < startTime + dashTime)
            {
                float dist_obj_dash = hit.distance;
                Physics.Raycast(transform.position, transform.forward, out hit, 40f);
                if (dist_obj_dash < 3f)
                {
                    Debug.Log("parar");
                    dashobj = false;
                    DashSpeed = 0f;
                    rb.velocity = Vector3.zero;
                }
               
                transform.Translate(transform.forward * DashSpeed*Time.deltaTime, Space.World);
                Debug.Log("NosePara");
               
                dashobj = false;
                yield return null;
            }
            DashSpeed = 40f;    
            
        }

    }
    



}

/* void OnCollisionEnter(Collision column)
    {
        if (column.gameObject.tag == "Obj_Destru")
        {
            Debug.Log("colison");
            StartCoroutine(Dashcol());
        }
        else
        {
            if (column.gameObject.tag == "Muros")
            {
                StartCoroutine(Dashcol());

            }

        }



    }
    IEnumerator Dashcol()
    {

        dashobj = false;
        if (dashobj == false)
        {
            DashSpeed = 0;
            yield return new WaitForSeconds(0.5f);
            dashobj = true;
        }


    }
    */

//Antiguas Habilidades
/*
 //Elemento2Fuego
    if (ElementoActivo >= 2 &&ElementoActivo<=2.99f)
    {

        if (Input.GetKey(KeyCode.Mouse1))//Propulsor
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up* propulsion, ForceMode.Acceleration);


gasolina -= 1;
            if (gasolina <= 0)
            {

                ElementoActivo = 0;
                gasolina = 1500;
            }
        }




    }
    if (ElementoActivo >= 3 && ElementoActivo <= 3.99f)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            HabilidadPlanta_Vida();
numerocuraciones += 1;
            if (numerocuraciones >= 2)
            {
                ElementoActivo = 0;
            }

        }



    }


}
public void HabilidadPlanta_Vida()
{

gameObject.GetComponent<vida_Player>().SumarVida_Player_normal(vidasumada);
*/



