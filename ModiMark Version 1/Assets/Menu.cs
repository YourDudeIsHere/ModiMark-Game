using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //future me you better cook as im tired asf, good luck mf
    public Animator anim;
    AnimationClip Fade;
    public void PlayPushed()
    {
        anim.Play("MenuAnim");
    }
    public void FadeEvent(string Start)
    {
        
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
