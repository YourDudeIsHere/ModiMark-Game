
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
    public UIController healthbar;
    float health = UIController.health;

    void Start()

    {
         
        // Ensures that only the RigidBody2D component is looked at
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;

    }

    // Update is called once per frame

    void Update()

    { if (health < 0.5f)
        {
            health -= 1f;
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

            transform.position = respawnPoint;

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
            healthbar.Damage(0.001f);
            health -= (0.001f);
            Debug.Log("The health you have currently is"+health);
            Debug.Log("The Healthbar is at" + healthbar);
            if (health < 0f)
            {
                print("im a dumb piece of shit");
                transform.position = respawnPoint;
                health = 1f;
                healthbar.Damage(-1f);
            }


        }


    }
}
