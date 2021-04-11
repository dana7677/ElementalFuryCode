using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaDerrota : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CambiarDeDerrotaAMenu());
    }

    // Update is called once per frame
    IEnumerator CambiarDeDerrotaAMenu()
    {
      

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -4);
    }

}
