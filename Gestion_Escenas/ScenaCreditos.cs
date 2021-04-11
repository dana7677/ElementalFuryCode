using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CambiarDeCreditosAMenu());
    }

    // Update is called once per frame
    IEnumerator CambiarDeCreditosAMenu()
    {


        yield return new WaitForSeconds(97f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

}
