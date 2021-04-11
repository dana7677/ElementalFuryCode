using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uimineralesacercarse : MonoBehaviour
{
    public Transform jugador;
    public Canvas canvaspropio;
    public float rangoactivacion=10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        canvaspropio.gameObject.transform.LookAt(jugador);
        if (Vector3.Distance(transform.position, jugador.transform.position) < rangoactivacion)
        {
            canvaspropio.gameObject.SetActive(true);
        }
        if (Vector3.Distance(transform.position, jugador.transform.position) > rangoactivacion)
        {
            canvaspropio.gameObject.SetActive(false);
        }


    }

}