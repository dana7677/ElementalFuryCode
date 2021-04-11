using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano_Jugador : MonoBehaviour
{
    public int Dano_PNormal = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MeshJugador")
        {

            other.GetComponent<vida_Player>().RestarVida_Player_normal(Dano_PNormal);


        }

        Destroy(this.gameObject, 0.1f);
    }
}
