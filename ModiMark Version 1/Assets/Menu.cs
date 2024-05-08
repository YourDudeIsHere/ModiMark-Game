using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //future me you better cook as im tired asf, good luck mf
    public GameObject Play;
    public GameObject Option;
    public GameObject Quit;
    public Animator anim;
    AnimationClip Fade;
    public Button PlayButton; 
    public void PlayPushed()
    {
        //every statement with setactive false makes buttons disappear allowing for the buttons
        //to stay hidden.
        Play.SetActive(false);
        Option.SetActive(false);
        Quit.SetActive(false);  
        anim.Play("MenuAnim");
    }
    //Method below is used to seamlessy load into the next level from the menu
    public void FadeEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

}
