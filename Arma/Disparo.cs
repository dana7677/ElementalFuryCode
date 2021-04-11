using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Arma;
    public GameObject CambioMatsObj;
    public GameObject Armatruetrue;


    public bool disparos = true;
    //Balas y proyectil 
    public GameObject proyectil;

    public float DisparoActivo;

    public GameObject Bala_Fuego;
    public GameObject Bala_Planta;
    public GameObject Bala_Agua;
    public GameObject Bala_Normal;
    public int dist_G = 20;
    public bool SiguienteRafaga;

    //Rayo laser
    public GameObject laserPrefab;
    public GameObject firePoint;
    public GameObject Salidalaser;
    private GameObject spawnedLaser;
    public bool laserdmg;
    public int distance = 100;
    public float Dano_Agua = 30f;
    public float Dano_dif = 15f;
    public bool lasernomasdmg;

    bool semRafaga = false;

    //
    public int maxAmmo = 10000000;
    public int MunicionAgua;
    public int MunicionFuego;
    public int MunicionPlanta;
    public int MunicionNormal;
    public int currentAmmo;
    public int restaBalas;

    public AmmoBar ammoBar;
    //Sonidos
    public GameObject sonidogranada;
    public GameObject sonidorafaga;
    public GameObject sonidoLaser;
    public GameObject sonidoShootNormal;
    public bool SemSonAgua = true;

    // conexioncambiomat
    public float MatArmaCh;
    
    // Start is called before the first frame update
    void Start()
    {
        MunicionAgua = 1000;
        MunicionFuego = 10;
        MunicionPlanta = 40;
        MunicionNormal = 1000;

        spawnedLaser = Instantiate(laserPrefab, Salidalaser.transform) as GameObject;
        DisableLaser();
        laserdmg = true;
        lasernomasdmg = true;
        //Debug.Log("PruebaCollab");
    }

    // Update is called once per frame
    public void CambiarDisparo(int Elemento)
    {
        DisparoActivo = 0;
        DisparoActivo += Elemento;
        MatArmaCh = DisparoActivo;
        CambioMatsObj.GetComponent<CambioMatsArma>().CambiarMatArma(MatArmaCh);
        Armatruetrue.GetComponent<ControlAnimacionesArma>().CambioElemActivo(MatArmaCh);
        if (DisparoActivo >= 1 && DisparoActivo <= 1.99f)
        {
            maxAmmo = MunicionAgua;
            restaBalas = 1;
        }
        if (DisparoActivo >= 2 && DisparoActivo <= 2.99f)
        {
            maxAmmo = MunicionFuego;
            restaBalas = 1;
        }
        if (DisparoActivo >= 3 && DisparoActivo <= 3.99f)
        {
            maxAmmo = MunicionPlanta;

            restaBalas = 4;

        }
        if (DisparoActivo >= 0 && DisparoActivo <= 0.99f)
        {
            maxAmmo = MunicionNormal;
            restaBalas = 1;
            
        }
        
        currentAmmo = maxAmmo;
        ammoBar.SetMaxAmmo(maxAmmo);
    }
    void Update()
    {
        //Tipos Disparo

        //DisparoNormal
                        if (DisparoActivo >= 0 && DisparoActivo <= 0.99f)
                        {
                            DisableLaser();
                            proyectil = Bala_Normal;
                            maxAmmo = MunicionNormal;
                            ammoBar.SetMaxAmmo(maxAmmo);
                            if (Input.GetKey(KeyCode.Mouse0))
                            {
                                if (disparos == true)
                                {


                                    GameObject bala = Instantiate(proyectil, Arma.transform.position + Arma.transform.forward * 0.5f, Arma.transform.rotation);
                                    bala.GetComponent<Rigidbody>().AddForce(Arma.transform.forward * 8000f);
                                    disparos = false;

                                    StartCoroutine(MunicionBaja());
                                    StartCoroutine(Cadencia());
                                    //StartCoroutine(MunicionBaja());

                                }

                            }

                        }
                        //Debug.DrawRay(transform.position, transform.forward * distance, Color.blue, 10f);
                        //AGUA
                        if (DisparoActivo >= 1 && DisparoActivo <= 1.99f)
                        {
                            //proyectil = Bala_Agua;

                            if (Input.GetKeyDown(KeyCode.Mouse0))
                            {
                                EnableLaser();


                            }
                            if (Input.GetKeyUp(KeyCode.Mouse0))
                            {
                                DisableLaser();
                            }
                            if (Input.GetKey(KeyCode.Mouse0))
                            {


                                MunicionAgua -= 1;
                                UpdateLaser();
                                Debug.DrawRay(firePoint.transform.position, firePoint.transform.forward * distance, Color.blue, 10f);

                                
                                
                                    StartCoroutine(CadenciaAgua());
                                    StartCoroutine(MunicionBaja());
                                    if (SemSonAgua == true)
                                    {
                                        StartCoroutine(SonAgua());
                                        SemSonAgua = false;
                                    }

                                    if (lasernomasdmg == true)
                                    {
                                        StartCoroutine(laserdmgtocho());
                                        
                                        lasernomasdmg = false;
                                    }
                                   
                    

                                



                            }


                            if (MunicionAgua <= 0)
                            {
                                Armatruetrue.GetComponent<ControlAnimacionesArma>().CambioElemActivo(MatArmaCh);
                                DisparoActivo = 0;
                                DisableLaser();
                                MunicionAgua = 1000;
                                StartCoroutine(CambioMat());
                            }
                        }
                        //Fuego
                        if (DisparoActivo >= 2 && DisparoActivo <= 2.99f)
                        {
                         DisableLaser();
                            proyectil = Bala_Fuego;
                            if (Input.GetKey(KeyCode.Mouse0))
                            {
                                if (disparos == true)
                                {
                                    GameObject Arma = transform.GetChild(0).gameObject;

                                    GameObject bala = Instantiate(proyectil, Arma.transform.position + Arma.transform.forward * 0.5f, Arma.transform.rotation);
                                    bala.GetComponent<Rigidbody>().AddForce(Arma.transform.up * dist_G + Arma.transform.forward * 8000f);
                                    disparos = false;
                                    

                                    MunicionFuego -= 1;
                                    StartCoroutine(CadenciaFuego());
                                    StartCoroutine(MunicionBaja());
                                     
                                    
                                 }

                            }
                            if (MunicionFuego <= 0)
                            {
                                DisparoActivo = 0;
                                MunicionFuego = 10;
                                StartCoroutine(CambioMat());
                            }
                        }


                        //Planta
                        if (DisparoActivo >= 3 && DisparoActivo <= 3.99f)
                        {
                            DisableLaser();
                            proyectil = Bala_Planta;
                            if (Input.GetKey(KeyCode.Mouse0))
                            {
                                StartCoroutine(Rafaga());
                                //StartCoroutine(MunicionBaja());
                            



                            }

                            if (MunicionPlanta <= 0)
                            {
                                DisparoActivo = 0;
                                 StartCoroutine(CambioMat());
                                MunicionPlanta = 40;
                                 
                            }

                        }


        IEnumerator Cadencia()
        {
            
            Instantiate(sonidoShootNormal, firePoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            disparos = true;
        }
        IEnumerator CadenciaFuego()
        {
            Instantiate(sonidogranada, firePoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            disparos = true;
        }
   
        IEnumerator CadenciaAgua()
        {
           
            
            yield return new WaitForSeconds(0.5f);
           

        }
        IEnumerator SonAgua() 
        {

            Instantiate(sonidoLaser, firePoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            SemSonAgua = true;
        }
        IEnumerator laserdmgtocho()
        {
            
            yield return new WaitForSeconds(0.2f);
            Danolaser();
            lasernomasdmg = true;

        }

        IEnumerator Rafaga()
        {
            if (semRafaga == false)
            {
                semRafaga = true;
                int cant = 4;
                Instantiate(sonidorafaga, firePoint.transform.position, Quaternion.identity);
                for (int x = 1; x <= cant; x++)
                {
                    //Disp
                    GameObject Arma = transform.GetChild(0).gameObject;     
                    GameObject bala = Instantiate(proyectil, Arma.transform.position + Arma.transform.forward * 0.5f, Arma.transform.rotation);
                    bala.GetComponent<Rigidbody>().AddForce(Arma.transform.forward * 2800f);
                    MunicionPlanta -= 1;
                    yield return new WaitForSeconds(0.1f);

                }
                StartCoroutine(MunicionBaja());
                yield return new WaitForSeconds(0.3f);
                semRafaga = false;
            }

        }

        IEnumerator MunicionBaja()
        {
            currentAmmo -= restaBalas;

            if (DisparoActivo >= 0 && DisparoActivo <= 0.99f)
            {
                currentAmmo += restaBalas;
                ammoBar.SetAmmo(currentAmmo);
            }
                ammoBar.SetAmmo(currentAmmo);

            yield return new WaitForSeconds(0.1f);
        }
        IEnumerator CambioMat()
        {
            
            MatArmaCh = DisparoActivo;
            CambioMatsObj.GetComponent<CambioMatsArma>().CambiarMatArma(MatArmaCh);
            Armatruetrue.GetComponent<ControlAnimacionesArma>().CambioElemActivo(MatArmaCh);
            yield return new WaitForSeconds(0.01f);


        }
      
    }
    


        //RayoLaser

    void EnableLaser()
    {

        spawnedLaser.SetActive(true);
    }

    void UpdateLaser()
    {

        if (firePoint != null)
        {
            if (DisparoActivo >= 1 && DisparoActivo <= 1.99f)
            {
                spawnedLaser.transform.position = Salidalaser.transform.position;
            }

        }
    }

    void DisableLaser()
    {

        spawnedLaser.SetActive(false);
    }

    //LaserDanoenemigos
    public void Danolaser()
    {
        Debug.Log("proceso");

        
        
        RaycastHit info;
        
        
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out info, distance))
            {

                //Debug.Log("target");

                Debug.Log(info);
                    if (info.collider.tag == "Enemigo_Normal")
                    {

                        info.collider.GetComponent<vida_enemigo_normal>().RestarVidNorm_dif(Dano_dif);
                        


                    }
                    if (info.collider.tag == "Enemigos_Agua")
                    {

                        info.collider.GetComponent<vida_enemigo_Agua>().RestarVidAgua_dif(Dano_dif);
                         Debug.Log("eiiiii");
                        

                    }
                    if (info.collider.tag == "Enemigos_Planta")
                    {
                        info.collider.GetComponent<Vida_Enemigos_Planta>().RestarVidPlanta_dif(Dano_dif);
                        
                    }
                    if (info.collider.tag == "Enemigos_Fuego")
                    {

                        info.collider.GetComponent<vida_enemigo_Fuego>().RestarVida_enemigo_Fuego(Dano_Agua);

                        
                    }

                


            }

        
           

    }
}

