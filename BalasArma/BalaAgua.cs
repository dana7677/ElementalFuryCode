using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAgua : MonoBehaviour
{
    public int Dano_Agua = 30;
    public float Dano_dif = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigos_Fuego")
        {

            other.GetComponent<vida_enemigo_Fuego>().RestarVida_enemigo_Fuego(Dano_Agua);


        }
        if (other.tag == "Enemigos_Agua")
        {

            other.GetComponent<vida_enemigo_Agua>().RestarVidAgua_dif(Dano_dif);


        }
        if (other.tag == "Enemigos_Planta")
        {
            other.GetComponent<Vida_Enemigos_Planta>().RestarVidPlanta_dif(Dano_dif);

        }
        if (other.tag == "Enemigo_Normal")
        {

            other.GetComponent<vida_enemigo_normal>().RestarVidNorm_dif(Dano_dif);


        }
    }
}
