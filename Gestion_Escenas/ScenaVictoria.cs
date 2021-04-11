using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaVictoria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CambiarDeVictoriaACreditos());
    }

    // Update is called once per frame
    IEnumerator CambiarDeVictoriaACreditos()
    {


        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

}
