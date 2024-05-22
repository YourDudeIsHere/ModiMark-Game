using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isTouchingGround;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isTouchingGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGround = false;
    }
}
