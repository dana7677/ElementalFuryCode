using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaResetMineral : MonoBehaviour
{
    //Planta=3
    public int Elemento = 3;
    public int Elemento1 = 3;
    public GameObject Arma;
    public GameObject mineralscript;
    public GameObject vidaplayer;
    public int vidasumada = 10;
    public GameObject gestionadorminerales;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            other.GetComponent<Habilidades>().CambiarElemento(Elemento);
            Arma.GetComponent<Disparo>().CambiarDisparo(Elemento);
            vidaplayer.GetComponent<vida_Player>().SumarvidaPlayerMineral(vidasumada);

            gestionadorminerales.GetComponent<gestionminerales>().ResetearMineral(Elemento1);

            mineralscript.gameObject.SetActive(false);


        }





    }
}
