using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static float health = 1f;

    public SpriteRenderer spriterenderer;
    public Sprite HealthBar_Full;
    public Sprite Bar_Full;
    public Sprite HealthBar_1;
    public Sprite HealthBar_2;
    public Sprite HealthBar_3;
    public Sprite HealthBar_4;
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

        if (health < 0.4)
        {
            barimage.color = Color.red;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSize(health);

        if (gameObject.name == "Border")
        {
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
                GetComponent<Image>().sprite = HealthBar_4;
            }
        }
        if (gameObject.name == "Bar")
        {   
            if(health < 1f && 0.8f > health)
            {
                GetComponent<Image>().sprite = Bar_Full;
            }
            if(health <0.8f && health > 0.6f)
            {
                GetComponent<Image>().sprite = Bar_1;
            }
            if (health < 0.6f && health > 0.5f)
            {
                GetComponent<Image>().sprite = Bar_2; 
            }
            if(health < 0.5f && health > 0.3f)
            {
                GetComponent<Image>().sprite = Bar_3;
            }
            if (health < 0.3f && health > 0f)
            {
                GetComponent <Image>().sprite = Bar_4;
            }
        }
    }
    public void SetSize (float size)
    {
        barimage.fillAmount = size;
    }
    public void Damage(float damage)
    {
        if((health-=damage)>= 0f)
        {
            health -= damage;
            if (health == 0f)
            {
                
            }
        } 
    }
  
}

