using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Obj : MonoBehaviour
{
    public float vida = 60;
    public void RestarVida_Objetos(int Dano_Obj)
    {

        vida -= Dano_Obj;




        if (vida <= 0)
        {





            Destroy(this.gameObject);

        }
    }
}
