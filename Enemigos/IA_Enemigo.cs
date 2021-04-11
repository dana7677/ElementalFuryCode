using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IA_Enemigo : MonoBehaviour
{
    public enum IAState
    {
        Idle,
        Patrol,
        Move,
        Attack,
        Return,
    }
    //RayCast Gracias al raycast si me escondo detras de un muro la detección no se dara 
    public float distance = 40f;

    public float Rangoactivaciondetect = 50f;

    //Cadencia Una cadencia de ataque del enemigo con corutinas
    public bool CadenciaActive;
    //animator He agregado animaciones a los diferentes estados del personaje
    public Animator animator_enem;

    public IAState estadoActual = IAState.Idle;

    private NavMeshAgent navAgent;
    public GameObject refJugador;
    public GameObject meshjugador;
    public float RangoVision;
    public float RangoAtaque;
    public float RangoAtaqueCuerpoACuerpo;
    public Transform jugador;
    public Transform[] tablaRuta;
    public int indiceRuta;

    public bool tiempoEspera;
    public bool semfcorespera;
    //Disparo
    public GameObject Enemigo;
    public GameObject proyectil;
    public GameObject soldado;
    public GameObject salidabala;
    //Cuerpo a cuerpo
    public int Dano_PNormal = 10;
    //Sonidos
    public GameObject sonidoShootEnemy;
    void Start()
    {
        CadenciaActive = true;
        RangoAtaque = 10f;
        RangoAtaqueCuerpoACuerpo = 4f;
        RangoVision = 20f;

        navAgent = GetComponent<NavMeshAgent>();

        tiempoEspera = false;
        semfcorespera = true;
        indiceRuta = 0;

        animator_enem = gameObject.GetComponent<Animator>();
        StartCoroutine(Deteccion());

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(this.transform.position, (refJugador.transform.position - this.transform.position).normalized * distance, Color.blue, 0.5f);

        switch (estadoActual)
        {
            case IAState.Idle:

                navAgent.SetDestination(transform.position); //le estoy mandando su propia posicion para que el agente se mantenga quieto

                animator_enem.SetBool("IdleReturn", true);

                if (tiempoEspera == true) //Espera 2 segundos ya que el tiempo de espera que le he puesto es 2 segundos
                {


                    estadoActual = IAState.Patrol;//cuando haya pasado el tiempo cambiamos al estado de patrulla
                    Debug.Log("cambioaIdle");
                    tiempoEspera = false;

                }

                if (semfcorespera == true)
                {
                    StartCoroutine(Tiempoparaespera());
                    semfcorespera = false;
                }
                break;

            case IAState.Patrol:

                navAgent.SetDestination(tablaRuta[indiceRuta].position);//Le mandamos el primer destino de la ruta 

                animator_enem.SetBool("IdleReturn", false);

                //MejoraDeteccion

                Debug.Log("EstoyenPatrol");

                if (Vector3.Distance(transform.position, tablaRuta[indiceRuta].position) < 2f)
                {
                    indiceRuta++;
                    if (indiceRuta >= tablaRuta.Length)// Cuando lleguemos al ultimo valor de la tabla volveremos al punto inicial 
                    {
                        indiceRuta = 0;
                    }

                }


                break;






            case IAState.Move:

                navAgent.speed = 6;//Velocidad a la que me persigue el agente
                navAgent.SetDestination(refJugador.transform.position);
                animator_enem.SetFloat("corridocont", 6);


                if (Vector3.Distance(transform.position, refJugador.transform.position) < RangoAtaque)
                {
                    if (Vector3.Angle(this.transform.forward, refJugador.transform.position - this.transform.position) < 30)
                    {
                        estadoActual = IAState.Attack;
                    }

                }
                if (Vector3.Distance(transform.position, refJugador.transform.position) > RangoVision)
                {
                    estadoActual = IAState.Return;
                }

                break;
            case IAState.Attack:

                //Que rote todo el rato hacia el 
                Quaternion rotTarget = Quaternion.LookRotation(jugador.transform.position - soldado.transform.position);
                soldado.transform.rotation = Quaternion.RotateTowards(soldado.transform.rotation, rotTarget, 2);

                if (CadenciaActive == true)
                {
                    if (Vector3.Distance(transform.position, refJugador.transform.position) > RangoAtaqueCuerpoACuerpo)
                    {
                        if (Vector3.Distance(transform.position, refJugador.transform.position) < RangoAtaque)
                        {
                            //soldado.transform.LookAt(jugador);

                            CadenciaActive = false;
                            StartCoroutine(DisparoConAnimacion());






                        }
                    }
                    if (Vector3.Distance(transform.position, refJugador.transform.position) < RangoAtaqueCuerpoACuerpo)
                    {
                        StartCoroutine(CuerpoACuerpoAnimacionDmg());
                        
                        
                        CadenciaActive = false;
                        
                    }
                }
                if (Vector3.Distance(transform.position, refJugador.transform.position) > RangoVision)
                {
                    estadoActual = IAState.Return;
                }


                if (Vector3.Distance(transform.position, refJugador.transform.position) > RangoAtaque)
                {
                    navAgent.isStopped = false;
                    estadoActual = IAState.Move;
                }

                break;
            case IAState.Return:
                navAgent.speed = 3;
                semfcorespera = true;
                animator_enem.SetFloat("corridocont", 3);
                animator_enem.SetBool("IdleReturn", true);

                estadoActual = IAState.Idle;


                break;

        }
        Debug.Log(estadoActual);
        Debug.Log("estadodeahora");
    }

    IEnumerator Cadencia()
    {
        Debug.Log("Ia Atacando");


        yield return new WaitForSeconds(0.5f);
        animator_enem.SetBool("AtaqueCerca", false);
        animator_enem.SetBool("AtaqueDistancia", false);
        CadenciaActive = true;


    }
    IEnumerator Tiempoparaespera()
    {
        yield return new WaitForSeconds(2f);
        tiempoEspera = true;

    }
    IEnumerator Deteccion()
    {
        while (true)
        {
            if (estadoActual == IAState.Patrol)
            {
                //Un primer if con el area donde te detecta, un segundo if con el angulo , el cono y un tercer if con el raycast para ver si no estas detras de un muro.
                if (Vector3.Distance(transform.position, refJugador.transform.position) < Rangoactivaciondetect)
                {
                    Debug.Log("Detectado");
                    if (Vector3.Angle(this.transform.forward, refJugador.transform.position - this.transform.position) < 30)//Angulo de vision del enemigo cuanto menor mas ciego es
                    {
                        Debug.Log("AnguloDetectado");

                        RaycastHit info;

                        if (Physics.Raycast(this.transform.position, refJugador.transform.position - this.transform.position, out info, distance))
                        {
                            //Debug.Log(info.transform.tag);
                            //Debug.DrawRay(this.transform.position, (refJugador.transform.position - this.transform.position).normalized * distance, Color.red, 0.5f);
                            if (info.transform.tag == "Player")
                            {

                                Debug.Log("Detectadox3");
                                estadoActual = IAState.Move;
                                yield return new WaitForSeconds(0.01f);
                            }
                        }

                    }
                }

            }

            yield return new WaitForSeconds(0.01f);
        }

    }
    IEnumerator DisparoConAnimacion()
    {

        navAgent.isStopped = true;
        animator_enem.SetBool("AtaqueDistancia", true);
        StartCoroutine(Salidabalota());
        yield return new WaitForSeconds(1.29f);

        StartCoroutine(Cadencia());


    }
    IEnumerator Salidabalota()
    {

        yield return new WaitForSeconds(1.3f);
        GameObject Enemigo = transform.GetChild(0).gameObject;

        GameObject bala = Instantiate(proyectil, salidabala.transform.position + salidabala.transform.forward * 0.5f, salidabala.transform.rotation);
        bala.GetComponent<Rigidbody>().AddForce(salidabala.transform.forward * 2600f);
        Instantiate(sonidoShootEnemy, soldado.transform.position, Quaternion.identity);

    }

    IEnumerator CuerpoACuerpoAnimacionDmg() 
    {
        animator_enem.SetBool("AtaqueCerca", true);
        yield return new WaitForSeconds(0.5f);
        meshjugador.GetComponent<vida_Player>().RestarVida_Player_normal(Dano_PNormal);
        StartCoroutine(Cadencia());

    }
}

