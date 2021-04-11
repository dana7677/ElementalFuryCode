using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vida_enemigo_Fuego : MonoBehaviour
{
    public float vida = 60;
    public Image barradevida_Enemigo;
    public GameObject Piernotas;
    public Animator animator;
    public Canvas canvaspropio;
    public Transform jugador;
    public GameObject soldadoFuego;
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


    //public int numOfChildrenPierna= 30;
    public bool semaforoMuerte = false;
    //animator muerte
    public Animator animator_enem;
    public GameObject GestionadorDerrota;
    public int Valor = 1;
    public int contFuego = 1;
    public void RestarVida_enemigo_Fuego(float Dano_Agua)
    {

        vida -= Dano_Agua;




        if (vida <= 0)
        {
            
            StartCoroutine(MuertenemiFuego());

            animator.Play("Muerte");

            

        }
    }
    public void RestarVidFuego_dif(float Dano_dif)
    {

        vida -= Dano_dif;




        if (vida <= 0)
        {
           
            StartCoroutine(MuertenemiFuego());

            animator.Play("Muerte");

           

        }
    }
    void Update()
    {
  
        canvaspropio.gameObject.transform.LookAt(jugador);
        barradevida_Enemigo.fillAmount = vida / 60;
    }
    IEnumerator MuertenemiFuego() 
    {
        if (semaforoMuerte == false)
        {
            semaforoMuerte = true;

            animator_enem.SetBool("muerte", true);
            Debug.Log("ejecuta");
            
           Cabeza.material=material_Cabeza;
           Pierna1.material=material_Piernas;
           Pierna2.material = material_Piernas;
           Cuello.material=material_Cuello;
           Brazos1.material=material_Brazos;
           Brazos2.material = material_Brazos;
           Nucleo.material=material_Nucleo;
           Pecho.material=material_Pecho;
           /*
           Cabeza.material.DetachChildren();
           GetComponentInChildren.material = material_Cabeza;


           MeshRenderer Cabezota = Pechote.GetComponent< MeshRenderer > ();


           
           // Hemos creado Emptys que sean parents de los objetos que forman la pierna, el brazo y la idea seria poder hacer que cambiara el material diciendole que lo cambie a todos sus hijos pero no logro hacerlo 

            int numOfChildrenPierna = transform.childCount;
            for (int i = 0; i < numOfChildrenPierna; i++)
            {
                List<Material> currentMats = new List<Material>();
                currentMats.Add(material_Piernas);
                GameObject Piernotas = transform.GetChild(i).gameObject;
                Piernotas.GetComponent<Renderer>().materials = currentMats.ToArray();
                Debug.Log(i);
                
            }
            */


            /*float cont = -1;
            while (cont < 1)
            {
                RenderENEMIGOfUEGO.material.SetFloat("Vector1_57E1603A", cont);
                cont += Time.fixedDeltaTime*1.5f;
                yield return new WaitForFixedUpdate();
            }
            */




            yield return new WaitForSeconds(0.7f);
            GestionadorDerrota.GetComponent<ControlEnemigos>().RestarFuego(contFuego);
            GestionadorDerrota.GetComponent<ControlEnemigos>().EnemigoMuerto(Valor);
            Destroy(soldadoFuego.gameObject);
        }
    }
}

