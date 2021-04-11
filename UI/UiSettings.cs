using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSettings : MonoBehaviour
{
    public Dropdown DropResoluciones;
    Resolution[] resList;

    public Dropdown DropCalidad;

    // Start is called before the first frame update
    void Start()
    {
        CargarResoluciones();
        CargarCalidad();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }


    void CargarResoluciones()
    {
        DropResoluciones.ClearOptions();
        List<string> options = new List<string>(); //Para la lista del despegable
        resList = Screen.resolutions;  //Array real con las resoluciones disponibles
        int currentResIndex = 0;


        List<Resolution> resLimpios = new List<Resolution>();
        foreach (Resolution r in resList)
        {
            if (resLimpios.Count > 0)
            {
                if (resLimpios[resLimpios.Count - 1].height == r.height && resLimpios[resLimpios.Count - 1].width == r.width)
                {
                    continue;
                }
            }
            resLimpios.Add(r);
        }
        resList = resLimpios.ToArray();


        for (int i = 0; i < resList.Length; i++)
        {
            string option = resList[i].width + " x " + resList[i].height;

            options.Add(option);

            //Para detectar la resolución actual y cuardarlo en el index
            if (resList[i].width == Screen.currentResolution.width && resList[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        DropResoluciones.AddOptions(options);
        DropResoluciones.RefreshShownValue();
        DropResoluciones.value = currentResIndex;
    }

    public void CambioResolucion(int n)
    {
        Resolution resNueva = resList[n];
        Screen.SetResolution(resNueva.width, resNueva.height, Screen.fullScreen);
        //Debug.Log(Screen.currentResolution);
    }

    void CargarCalidad()
    {
        DropCalidad.value = QualitySettings.GetQualityLevel();
    }

    public void CambioCalidad(int n)
    {
        QualitySettings.SetQualityLevel(n);
    }

    public void CambioFullScreen(bool b)
    {
        Screen.fullScreen = b;
    }

    public void CambioTextura(int n)
    {
        QualitySettings.masterTextureLimit = n;
    }

    public void CambioAntialising(int n)
    {
        QualitySettings.antiAliasing = n;

    }



}