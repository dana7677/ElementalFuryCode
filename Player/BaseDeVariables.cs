using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeVariables : MonoBehaviour
{

    public float velocidadFB = 0.0f;
    public float velocidad_ProssFB = 0.0f;
    public float velocidadDI = 0.0f;
    public float velocidad_ProssDI = 0.0f;
    public float horizontalVelocidad;
    public float verticalVelocidad;

    public bool muevoderecha;
    public bool muevoizquierda;
    public bool muevodelante;
    public bool muevodetras;
    //Camara
    public GameObject Camera;
    //public GameObject Arma;
    float h;
    float v;
    //Salto
    public float fuerzaSalto;
    public bool PuedoSaltar;
    public Rigidbody rb;

    public bool corriendo=false;
    //Sonidos
    public GameObject sonidopasos;
    public GameObject sonidocorrer;
    public GameObject Sonidosalto;
    public bool SemfAndarSond = true;
    public bool SemfCorrerSond = true;
   

    // Start is called before the first frame update
    void Start()
   {
        rb = GetComponent<Rigidbody>();
   }
   
    // Update is called once per frame
    void Update()
   {
        
   }
    public virtual void Salto()
    {
        
        Vector3 floor = transform.TransformDirection(Vector3.down);//Vector que apunta hacia abajo
        Debug.DrawRay(transform.position, floor, Color.red, 1f);
        if (Physics.Raycast(transform.position, floor, 1.6f, 03))
        {
            PuedoSaltar = true;

        }
        else
        {
            PuedoSaltar = false;
        }

        if (PuedoSaltar)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                StartCoroutine(SonidoSalto());
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }

        }

    }

   public virtual void CamaraJugador()
   {
        h = horizontalVelocidad * Input.GetAxis("Mouse X");
        v = verticalVelocidad * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        Camera.transform.Rotate(-v, 0, 0);
        //Arma.transform.Rotate(-v, 0, 0);
   }
    public virtual void Movimiento() 
    {
        if (Input.GetKey(KeyCode.W))
        {

            velocidad_ProssFB += 0.01f;//Aceleradores por frame
            muevodelante = true;
            muevodetras = false;
            if (velocidad_ProssFB > 0.3)//limite de aceleracion Delante
            {
                velocidad_ProssFB = 0.3f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {

            velocidad_ProssFB -= 0.01f;//Aceleradores por frame
            muevodelante = false;
            muevodetras = true;
            if (velocidad_ProssFB < -0.3)//limite de aceleracion Atras
            {
                velocidad_ProssFB = -0.3f;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {

            velocidad_ProssDI += 0.01f;//Aceleradores por frame
            muevoderecha = true;
            muevoizquierda = false;
            if (velocidad_ProssDI > 0.3)//limite de aceleracion Derecha
            {
                velocidad_ProssDI = 0.3f;
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {

            velocidad_ProssDI -= 0.01f;//Aceleradores por frame
            muevoderecha = false;
            muevoizquierda = true;
            if (velocidad_ProssDI < -0.3)//limite de aceleracion Izquierda
            {
                velocidad_ProssDI = -0.3f;
            }

        }


        transform.Translate(transform.forward * velocidadFB * velocidad_ProssFB * Time.deltaTime, Space.World);//DelanteYAtras
        transform.Translate(transform.right * velocidadDI * velocidad_ProssDI * Time.deltaTime, Space.World);//DerechaYIzquierda

        if (Input.GetKeyUp(KeyCode.W))
        {
            muevodelante = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            muevodetras = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            muevoderecha = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            muevoizquierda = false;
        }
        if (muevodelante == false && velocidad_ProssFB > 0)
        {
            velocidad_ProssFB -= 0.01f;//Cantidad de frenada por Frame
            if (velocidad_ProssFB <= 0)
            {
                velocidad_ProssFB = 0;
            }

        }
        if (muevodetras == false && velocidad_ProssFB < 0)
        {
            velocidad_ProssFB += 0.01f;
            if (velocidad_ProssFB >= 0)
            {
                velocidad_ProssFB = 0;
            }

        }
        if (muevoderecha == false && velocidad_ProssDI > 0)
        {
            velocidad_ProssDI -= 0.01f;//Cantidad de frenada por Frame
            if (velocidad_ProssDI <= 0)
            {
                velocidad_ProssDI = 0;
            }

        }
        if (muevoizquierda == false && velocidad_ProssDI < 0)
        {
            velocidad_ProssDI += 0.01f;
            if (velocidad_ProssDI >= 0)
            {
                velocidad_ProssDI = 0;
            }

        }
        if(muevodelante==true|| muevodetras==true|| muevoderecha == true || muevoizquierda == true) 
        {
            if (corriendo == true) 
            {
                if(SemfCorrerSond == true)
                {
                    StartCoroutine(SonidoCorrer());
                    SemfCorrerSond = false;
                }
                
            }
            else 
            {
                if (SemfAndarSond == true)
                {
                    StartCoroutine(SonidoAndar());
                    SemfAndarSond = false;
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            corriendo = true;
            velocidadFB = 30.0f;
            velocidadDI = 20.0f;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            corriendo = false;
            velocidadFB = 15.0f;
            velocidadDI = 10.0f;
        }


    }
    IEnumerator SonidoAndar()
    {
        
        Instantiate(sonidopasos, Camera.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SemfAndarSond = true;

    }
    IEnumerator SonidoCorrer()
    {
        
        Instantiate(sonidocorrer, Camera.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SemfCorrerSond = true;

    }

    IEnumerator SonidoSalto()
    {

       
        yield return new WaitForSeconds(0.2f);
        Instantiate(Sonidosalto, Camera.transform.position, Quaternion.identity);
        

    }


    
    /*IEnumerator SonidoCorrer()
    {
        Destroy(sonidocorrer.Instantiate);
        Destroy()
        yield return new WaitForSeconds(1f);
        SemfCorrerSond = true;

    }
    */
    /*public virtual void Dash()
    {
        if (Input.GetMouseButtonDown(1))
        {

            StartCoroutine(Dashproceso());
        }

        IEnumerator Dashproceso()
        {
            float startTime = Time.time;
            while (Time.time < startTime + dashTime)
            {
                transform.Translate(transform.forward * DashSpeed * Time.deltaTime, Space.World);

                yield return null;
            }


        }

    }
    */



}
