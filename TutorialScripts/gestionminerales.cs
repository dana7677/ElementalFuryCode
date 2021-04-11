using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionminerales : MonoBehaviour
{
    public bool SemMatArma=true;
    public float Mineralspawneo;
    public GameObject mineralverde;
    public GameObject mineralrojo;
    public GameObject mineralazul;
    public GameObject PuntoVerde;
    public GameObject PuntoAzul;
    public GameObject PuntoRojo;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    public void ResetearMineral(float Elemento1)
    {
        Mineralspawneo = 0;
        Mineralspawneo = Mineralspawneo + Elemento1;

        SemMatArma = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Mineralspawneo >= 1 && Mineralspawneo <= 1.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioAguita());
                SemMatArma = false;
            }

        }
        if (Mineralspawneo >= 2 && Mineralspawneo <= 2.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioFuego());
                SemMatArma = false;
            }

        }
        if (Mineralspawneo >= 3 && Mineralspawneo <= 3.99f)
        {
            if (SemMatArma == true)
            {
                StartCoroutine(CambioPlanta());
                SemMatArma = false;
            }


        }

    }
    IEnumerator CambioAguita()
    {

        
        yield return new WaitForSeconds(5f);
        mineralazul.gameObject.SetActive(true);
    }
    IEnumerator CambioFuego()
    {


        yield return new WaitForSeconds(5f);
        
        mineralrojo.gameObject.SetActive(true);
    }
    IEnumerator CambioPlanta()
    {


        yield return new WaitForSeconds(5f);
        
        mineralverde.gameObject.SetActive(true);
    }
}
