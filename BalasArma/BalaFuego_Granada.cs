using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
public class BalaFuego_Granada : MonoBehaviour
{
    public int radio = 20;
    public int Dano_Obj = 30;
    public int Dano_Enemigos_Planta = 20;
    public float I_explosionForce = 10;
    public float I_explosionRadius = 10;
    public float I_upforce = 30;
    public float Dano_dif = 1;
    public GameObject vfxgranadaPrefab;
    public GameObject granadafuego;
   
    // Start is called before the first frame update

  
    private void OnCollisionEnter(Collision collision)
    {
         Vector3 PuntoExplosion = granadafuego.transform.position;
        
        
        Collider[] resultados = Physics.OverlapSphere(this.transform.position, radio);

        Instantiate(vfxgranadaPrefab,PuntoExplosion,vfxgranadaPrefab.transform.rotation);
       
        foreach (Collider objetos in resultados)
        {
            if (objetos.transform.tag == "Obj_Destru")
            {

                Rigidbody Obj_Destru = objetos.gameObject.GetComponent<Rigidbody>();
                objetos.GetComponent<Vida_Obj>().RestarVida_Objetos(Dano_Obj);
                if (Obj_Destru != null)
                {
                    Debug.Log("deteccionfuego");
                    Obj_Destru.AddExplosionForce(I_explosionForce, PuntoExplosion, I_explosionRadius, I_upforce, ForceMode.Impulse);
                }

            }
            if (objetos.transform.tag == "Enemigos_Planta")
            {
                objetos.GetComponent<Vida_Enemigos_Planta>().RestarVida_Enemigos_Planta(Dano_Enemigos_Planta);

            }
            if (objetos.transform.tag == "Enemigos_Agua")
            {

                objetos.GetComponent<vida_enemigo_Agua>().RestarVidAgua_dif(Dano_dif);


            }
            if (objetos.transform.tag == "Enemigos_Fuego")
            {

                objetos.GetComponent<vida_enemigo_Fuego>().RestarVidFuego_dif(Dano_dif);


            }
            if (objetos.transform.tag == "Enemigo_Normal")
            {

                objetos.GetComponent<vida_enemigo_normal>().RestarVidNorm_dif(Dano_dif);


            }

        }
        
        Destroy(granadafuego.gameObject,0.1f);
        
    }
}
