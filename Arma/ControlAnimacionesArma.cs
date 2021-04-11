using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacionesArma : MonoBehaviour
{
    private Animator AnimContr;
    float v;
    float h;
    public float direccionpaso = 0.25f;
    public float DisparoActivo=0;

    // Start is called before the first frame update
    void Start()
    {
        AnimContr = GetComponent<Animator>();

    }
    public void CambioElemActivo(float MatArmaCh) 
    {
        DisparoActivo = MatArmaCh;
      



    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(DisparoActivo);
        if (AnimContr != null)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            AnimContr.SetFloat("velocidad", v);
            AnimContr.SetFloat("direccion", h, direccionpaso, Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            AnimContr.SetBool("Salto", true);


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AnimContr.SetBool("Salto", false);


        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AnimContr.SetBool("Run", true);



        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            AnimContr.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            AnimContr.SetBool("Dash", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            AnimContr.SetBool("Dash", false);
        }
        //Disparos
        if (DisparoActivo >= 1 && DisparoActivo <= 1.99f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispLaser", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispLaser", false);
            }
            
        }
        if (DisparoActivo >= 2 && DisparoActivo <= 2.99f)
        {
            AnimContr.SetBool("DispLaser", false);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispFuego", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispFuego", false);
            }

        }
        if (DisparoActivo >= 3 && DisparoActivo <= 3.99f)
        {
            AnimContr.SetBool("DispLaser", false);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispRafaga", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispRafaga", false);
            }

        }
        if (DisparoActivo >= 0 && DisparoActivo <= 0.99f)
        {
            AnimContr.SetBool("DispLaser", false);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispNomal", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                AnimContr.SetBool("DispNomal", false);
            }


        }

       

    }
   

}
