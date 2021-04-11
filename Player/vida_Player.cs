using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vida_Player : MonoBehaviour
{
    public float vida = 100;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject JugadorReal;
    //DS
    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    public float colorSmoothing=6f;
    bool isTakingDamage;

    public void RestarVida_Player_normal(int Dano_PNormal)
    {
        isTakingDamage = true;
        currentHealth = currentHealth - Dano_PNormal;
        StartCoroutine(Recibiendodano());
        Debug.Log("restarvidaplayer");

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


            Destroy(JugadorReal.gameObject);

        }
       

    }
    public void SumarvidaPlayerMineral(int vidasumada)
    {

        if (currentHealth < 100) 
        {
            currentHealth = currentHealth + vidasumada;

        }
        
        
    }  

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    void Update()
    {
        
        Debug.Log(vida);

        healthBar.SetHealth(currentHealth);
        if (isTakingDamage==true)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
    }

    IEnumerator Recibiendodano()
    {

        yield return new WaitForSeconds(0.2f);

        isTakingDamage  = false;


    }


    /*
    public void SumarVida_Player_normal(int vidasumada)
    {
        if (vida <= 100)
        {
            vida = vida - vidasumada;
        }

    }
    */
}

