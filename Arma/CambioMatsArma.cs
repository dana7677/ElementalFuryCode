using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMatsArma : MonoBehaviour
{
    public float matarma = 0f;
    public bool SemMatArma;
    //Mat_Norm
    public Material material_Cristal_norm;
    public Material material_esfera_norm;
    //Mat_Agua
    public Material material_Cristal_Water;
    public Material material_esfera_Water;
    //Mat_Fuego
    public Material material_Cristal_fueg;
    public Material material_esfera_fueg;
    //Mat_Plant
    //Mat_Fuego
    public Material material_Cristal_Plant;
    public Material material_esfera_Plant;


    //PartesModelo

    public Renderer esfera;
    public Renderer ParteCristal;


    

    public void CambiarMatArma(float MatArmaCh)
    {
        matarma = 0;
        matarma+=MatArmaCh;
        SemMatArma = true;



    }


    void Update()
    {

        if (matarma >= 1 && matarma <= 1.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioAguita());
                SemMatArma = false;
            }
            
        }
        if (matarma >= 2 && matarma <= 2.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioFuego());
                SemMatArma = false;
            }

        }
        if (matarma >= 3 && matarma <= 3.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioPlanta());
                SemMatArma = false;
            }


        }
        if (matarma >= 0 && matarma <= 0.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioNormal());
                SemMatArma = false;
            }

        }



    }

    IEnumerator CambioAguita()
    {

        ParteCristal.material = material_Cristal_Water;
        esfera.material = material_esfera_Water;
        yield return new WaitForSeconds(0.01f);
    }
    IEnumerator CambioPlanta()
    {
        ParteCristal.material = material_Cristal_Plant;
        esfera.material = material_esfera_Plant;
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator CambioFuego()
    {

        ParteCristal.material = material_Cristal_fueg;
        esfera.material = material_esfera_fueg;
        yield return new WaitForSeconds(0.01f);
    }
    IEnumerator CambioNormal()
    {

        ParteCristal.material = material_Cristal_norm;
        esfera.material = material_esfera_norm;
        yield return new WaitForSeconds(0.01f);
    }
}
