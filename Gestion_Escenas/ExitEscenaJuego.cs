using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitEscenaJuego : MonoBehaviour
{
    public Canvas AjustesJuego;
    public Canvas UIJugador;
    public Canvas NUMEnemi;
    // Start is called before the first frame update
    void Start()
    {
        AjustesJuego.gameObject.SetActive(false);
        UIJugador.gameObject.SetActive(true);
        NUMEnemi.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            AjustesJuego.gameObject.SetActive(true);
            UIJugador.gameObject.SetActive(false);
            NUMEnemi.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
       
    }
    public void QuitarOptions()
    {
        AjustesJuego.gameObject.SetActive(false);
        UIJugador.gameObject.SetActive(true);
        NUMEnemi.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
