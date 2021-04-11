using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    //Fuego 2
    public int Elemento = 2;
    
    public GameObject Arma;
    public GameObject mineralscript;
    public GameObject vidaplayer;
    public int vidasumada = 10;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.GetComponent<Habilidades>().CambiarElemento(Elemento);
            Arma.GetComponent<Disparo>().CambiarDisparo(Elemento);
            vidaplayer.GetComponent<vida_Player>().SumarvidaPlayerMineral(vidasumada);

            Debug.Log("nicoooo");
            Destroy(this.gameObject);
            

        }

        


    }
}
