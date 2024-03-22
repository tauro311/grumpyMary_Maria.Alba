using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    public Animator anim;
    PlayerMovement playerScript;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        playerScript = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Unicorn")
        {
            playerScript.rBody.AddForce(Vector2.up * playerScript.jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);

            //Destroy(collider.gameObject);
            Enemy Unicorn = collider.gameObject.GetComponent<Enemy>();

            Unicorn.UnicornDeath();
        }

        isGrounded = true;
        anim.SetBool("IsJumping", false);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
}
