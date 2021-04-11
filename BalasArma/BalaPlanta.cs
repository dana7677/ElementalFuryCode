using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlanta : MonoBehaviour
{
    public int Dano_Planta = 30;
    public float Dano_dif = 1;
    public GameObject granadaPlanta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigos_Agua")
        {

            other.GetComponent<vida_enemigo_Agua>().RestarVida_enemigo_Agua(Dano_Planta);


        }
        if (other.tag == "Enemigos_Planta")
        {
            other.GetComponent<Vida_Enemigos_Planta>().RestarVidPlanta_dif(Dano_dif);

        }
        if (other.tag == "Enemigos_Fuego")
        {

            other.GetComponent<vida_enemigo_Fuego>().RestarVidFuego_dif(Dano_dif);


        }
        if (other.tag == "Enemigo_Normal")
        {

            other.GetComponent<vida_enemigo_normal>().RestarVidNorm_dif(Dano_dif);


        }
        Destroy(granadaPlanta.gameObject, 0.1f);
    }


  

}
