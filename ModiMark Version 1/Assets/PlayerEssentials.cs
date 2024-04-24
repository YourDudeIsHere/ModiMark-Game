
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Public can be seen in the Inspector
    // Character speed and jump speed
    public float speed = 5f;
    public float jumpspeed = 8f;
    // The direction the character is moving (+ for ->) (- for <-)
    private float direction = 0f;
    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Vector3 respawnPoint;
    // The starting position of the character
    public GameObject fallDetector;
    // Allows the fall detector to be attatched to an object
    private Animator playerAnimation;
    // Start is called before the first frame update.
   // Everything underneath i use for referencing anything from the UI controller script
    public UIController healthbar;
    public UIController border;
    public bool reset;
    public UIController barimage;
    public UIController borderimage;
    // The gameobjects 
    public GameObject Border;
    public GameObject Bar;
    //
    public Sprite HealthBar_Full;
    public Sprite Bar_Full;

    
    void Start()

    {
         
        // Ensures that only the RigidBody2D component is looked at
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;

    }

    // Update is called once per frame

    void Update()

    { 
       
        #region Health

        border.health=healthbar.health;
        if (healthbar.health < -0.1f)
        {
            reset = true;
        }
        #endregion
        
        if (reset)
        {
            Respawn();
            
            
        }
        

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        // Makes a circle to detect if a player is touching the ground
        //isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f)

        {

            // Makes player go right if the direction variable is positive

            player.velocity = new Vector2(direction * speed, player.velocity.y);

            transform.localScale = new Vector2(1f, 1f);

        }

        else if (direction < 0f)

        {

            // Makes player go left if the direction variable is negative

            player.velocity = new Vector2(direction * speed, player.velocity.y);

            transform.localScale = new Vector2(-1f, 1f);

        }

        else

        {

            // Player not moving

            player.velocity = new Vector2(0, player.velocity.y);

        }

        // Spacebar is "Jump" 

        if (Input.GetButtonDown("Jump") && isTouchingGround)

        {

            // Jump

            player.velocity = new Vector2(player.velocity.x, jumpspeed);

        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.tag == "FallDetector")

        {

            Respawn();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Ground"))

        {

            isTouchingGround = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)

    {

        isTouchingGround = false;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Damage")
        {
            healthbar.health -= (0.003f);
        }


    }
    //This method underneath resets everything needed
    private void Respawn()
    {
        transform.position = respawnPoint;
        healthbar.health = 1f;
        Border.GetComponent<Image>().sprite = HealthBar_Full;
        Bar.GetComponent<Image>().sprite = Bar_Full;
        reset = false;
    }
}
