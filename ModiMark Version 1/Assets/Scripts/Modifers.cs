using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Modifers : MonoBehaviour
{
    public AnimationClip DoubleSpeed;
    public Sprite invisible;
    public Image mod;
    public Animator anim;
    //The random number generator's variable which produces the number
    int randomNumber;
    //This variable holds the last number outputted through the random number generator
    int lastNumber;
    //Method Used for variation in modifers.
    GameObject _Player;
    void NewRandomNumber()
    {
        randomNumber = Random.Range(1, 4);
        if (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(1, 4);
        }
        lastNumber = randomNumber;
    }
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        anim.SetInteger("Modifiers", 0);
        //Needed to randomly generate modifers (Only 3 for now)
        int randomNumber = Random.Range(1, 4);
        //Needed to reference variables from my Player script
       

        print(randomNumber);
        //Slows player down by half
        if (randomNumber == 1)
        {
            _Player.GetComponent<Player>().speed = 7f;
            _Player.GetComponent<Player>().jumpspeed = 9f;
            print("Now 50% Slower");
            anim.Play("50%SlowerMod");
            
        }
        //Player move jump half of their normale height
        else if (randomNumber == 2)
        {
            _Player.GetComponent<Player>().jumpspeed = 9f;
           print("Half the jump height");
            anim.Play("HalfJumpPower");
        }
        //Player goes a bit faster than normal (5 is the normal value)
        else if (randomNumber == 3)
        {
            _Player.GetComponent<Player>().speed = 9f;
            _Player.GetComponent<Player>().jumpspeed = 10f;
            print("Double speed");
            anim.Play("DS");
            
           
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

} 