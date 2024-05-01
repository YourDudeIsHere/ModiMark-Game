using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public float health;
 

    public SpriteRenderer spriterenderer;
    //The sprites used for the borders of the healthbar
    public Sprite HealthBar_Full;
    public Sprite HealthBar_1;
    public Sprite HealthBar_2;
    public Sprite HealthBar_3;
    public Sprite HealthBar_4;
    //The bar within the health border
    public Sprite Bar_Full;
    public Sprite Bar_1;
    public Sprite Bar_2;
    public Sprite Bar_3;
    public Sprite Bar_4;
    public Image barimage;
    public Image borderimage;
    

    // Start is called before the first frame update
    void Start()
    {
        Player _Player = FindObjectOfType<Player>();
        borderimage = GetComponent<Image>();
        barimage = GetComponent<Image>();

        health = barimage.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        barimage.fillAmount = health;

        switch (gameObject.name)
        {
            case "Border":

            Debug.Log(health);

            if (health < 1f && health > 0.8f) 
            {
                GetComponent<Image>().sprite = HealthBar_Full;
            }
            if (health < 0.8f && health > 0.6f)
            {
                GetComponent<Image>().sprite = HealthBar_1;
            }
            if (health < 0.6f && health > 0.5f)
            {
                GetComponent<Image>().sprite = HealthBar_2; 
            }
            if (health < 0.5f && health > 0.3f)
            {
                GetComponent<Image>().sprite = HealthBar_3;
            }
            if (health < 0.3f && health > 0f)
            {
                GetComponent <Image>().sprite = HealthBar_4;
            }
            break;

            case "Bar":


            if (health < 1f && health > 0.8f) 
            {
                GetComponent<Image>().sprite = Bar_Full;
            }
            if (health < 0.8f && health > 0.6f)
            {
                GetComponent<Image>().sprite = Bar_1;
            }
            if (health < 0.6f && health > 0.5f)
            {
                GetComponent<Image>().sprite = Bar_2; 
            }
            if (health < 0.5f && health > 0.3f)
            {
                GetComponent<Image>().sprite = Bar_3;
            }
            if (health < 0.3f && health > 0f)
            {
                GetComponent <Image>().sprite = Bar_4;
            }
            break;
                          
        }
    }


  
}

