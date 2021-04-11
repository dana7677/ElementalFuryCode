using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano_enemigo_normal : MonoBehaviour
{
    public int Dano_Normal = 30;
    public float Dano_dif = 8;
    public GameObject balanormal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo_Normal")
        {

            other.GetComponent<vida_enemigo_normal>().RestarVida_enemigo_normal(Dano_Normal);
            

        }
        if (other.tag == "Enemigos_Agua")
        {

            other.GetComponent<vida_enemigo_Agua>().RestarVidAgua_dif(Dano_dif);


        }
        if (other.tag == "Enemigos_Planta")
        {
            other.GetComponent<Vida_Enemigos_Planta>().RestarVidPlanta_dif(Dano_dif);

        }
        if (other.tag == "Enemigos_Fuego")
        {

            other.GetComponent<vida_enemigo_Fuego>().RestarVidFuego_dif(Dano_dif);


        }
        Destroy(balanormal.gameObject, 0.1f);
    }
}
