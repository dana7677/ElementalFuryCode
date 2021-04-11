﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vida_enemigo_Agua : MonoBehaviour
{
    public Transform jugador;
    public float vida = 60;
    public Image barradevida_Enemigo;
    public Animator animator;
    public Canvas canvaspropio;

    public GameObject enemigo_Agua;


    //Mat_Desv
    public Material material_Cabeza;
    public Material material_Piernas;
    public Material material_Cuello;
    public Material material_Brazos;
    public Material material_Nucleo;
    public Material material_Pecho;



    //PartesModelo

    public Renderer Cabeza;
    public Renderer Pierna1;
    public Renderer Pierna2;
    public Renderer Cuello;
    public Renderer Brazos1;
    public Renderer Brazos2;
    public Renderer Nucleo;
    public Renderer Pecho;
    // animator muerte
    public Animator animator_enem;
    public GameObject GestionadorDerrota;
    public int Valor = 1;
    public int contAgua = 1;
    public void RestarVida_enemigo_Agua(int Dano_Planta)
    {

        vida -= Dano_Planta;




        if (vida <= 0)
        {


            
            animator.Play("Muerte");

            StartCoroutine(MuertenemiAgua());

        }
    }
    public void RestarVidAgua_dif(float Dano_dif)
    {

        vida -= Dano_dif;




        if (vida <= 0)
        {


            
            animator.Play("Muerte");

            StartCoroutine(MuertenemiAgua());

        }
    }
    void Update()
    {
        canvaspropio.gameObject.transform.LookAt(jugador);

        barradevida_Enemigo.fillAmount = vida / 60;
    }



    public bool semaforoMuerte = false;
    IEnumerator MuertenemiAgua()
    {

        if (semaforoMuerte == false)
        {
            animator_enem.SetBool("muerte", true);
            semaforoMuerte = true;



            Cabeza.material = material_Cabeza;
            Pierna1.material = material_Piernas;
            Pierna2.material = material_Piernas;
            Cuello.material = material_Cuello;
            Brazos1.material = material_Brazos;
            Brazos2.material = material_Brazos;
            Nucleo.material = material_Nucleo;
            Pecho.material = material_Pecho;
            yield return new WaitForSeconds(0.7f);
            GestionadorDerrota.GetComponent<ControlEnemigos>().RestarAgua(contAgua);
            GestionadorDerrota.GetComponent<ControlEnemigos>().EnemigoMuerto(Valor);
            Destroy(enemigo_Agua.gameObject);
        }
        
    }
    
}

