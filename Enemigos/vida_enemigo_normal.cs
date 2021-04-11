using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vida_enemigo_normal : MonoBehaviour
{
    public float vida = 60;
    public Image barradevida_Enemigo;
    public Animator animator;
    public Canvas canvaspropio;
    public Transform jugador;

    public void RestarVida_enemigo_normal(int Dano_Normal)
    {

        vida -= Dano_Normal;




        if (vida <= 0)
        {



            animator.Play("Muerte");

            Destroy(this.gameObject);

        }
    }
    public void RestarVidNorm_dif(float Dano_dif)
    {

        vida -= Dano_dif;




        if (vida <= 0)
        {



            animator.Play("Muerte");

            Destroy(this.gameObject);

        }
    }
    void Update()
        {

        canvaspropio.gameObject.transform.LookAt(jugador);

        barradevida_Enemigo.fillAmount = vida / 60;
        }
    
}
