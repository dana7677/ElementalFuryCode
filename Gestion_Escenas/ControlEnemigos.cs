using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlEnemigos : MonoBehaviour
{
    public int cantidadenemigosdead;
    public int cantidadenemigos = 1;
    //InfoEnemigos
    public Text FuegoTxt;
    public Text AguaTxt;
    public Text PlantaTxt;
    //CambioImagenes
    public Image FuegoRoja;
    public Image AguaRoja;
    public Image PlantaRoja;
    public Image FuegoVerde;
    public Image AguaVerde;
    public Image PlantaVerde;
    //NumeroEnemigos
    public int numeroFuego = 0;
    public int numeroAgua = 0;
    public int numeroPlanta = 0;

    // Start is called before the first frame update
    void Start()
    {
        cantidadenemigosdead = 0;
        FuegoRoja.gameObject.SetActive(true);
        AguaRoja.gameObject.SetActive(true);
        PlantaRoja.gameObject.SetActive(true);
        FuegoVerde.gameObject.SetActive(false);
        AguaVerde.gameObject.SetActive(false);
        PlantaVerde.gameObject.SetActive(false);
    }
    public void EnemigoMuerto(int Valor) 
    {
        cantidadenemigosdead = cantidadenemigosdead + Valor;



    }
    // Update is called once per frame
    void Update()
    {

        if (cantidadenemigosdead >= cantidadenemigos) 
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


        }

        FuegoTxt.text = numeroFuego.ToString("00");
        PlantaTxt.text = numeroPlanta.ToString("00");
        AguaTxt.text = numeroAgua.ToString("00");

        if (numeroFuego <= 0)
        {
            FuegoRoja.gameObject.SetActive(false);
            FuegoVerde.gameObject.SetActive(true);

        }
        if (numeroAgua <= 0)
        {
            AguaRoja.gameObject.SetActive(false);
            AguaVerde.gameObject.SetActive(true);

        }
        if (numeroPlanta <= 0)
        {
            PlantaRoja.gameObject.SetActive(false);
            PlantaVerde.gameObject.SetActive(true);

        }

    }
    public void RestarFuego(int contFuego)
    {

        numeroFuego = numeroFuego - contFuego;

    }
    public void RestarPlanta(int contPlanta)
    {

        numeroPlanta = numeroPlanta - contPlanta;

    }
    public void RestarAgua(int contAgua)
    {

        numeroAgua = numeroAgua - contAgua;

    }
}
