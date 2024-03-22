using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
    public GroundSensor sensor;
    public SpriteRenderer render;
    public Animator anim;
    AudioSource source;

    public Vector3 newPosition = new Vector3(50, 5, 0);

    public float movementSpeed = 5;
    public float jumpForce = 10;
    private float inputHorizontal;

    public bool jump = false;

    public AudioClip jumpSound;
    

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Teletransporta al personaje a la posicion de la variable newPosition
        //transform.position = newPosition
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");

        //transform.position = transform.position + new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        //transform.position += new Vector3(inputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;

        /*if(jump == true)
        {
           Debug.Log("estoy saltando"); 
        }
        else if(jump == false)
        {
            Debug.Log("estoy en el suelo");
        }
        else
        {
            Debug.Log("afsdg");
        }*/

        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
            source.PlayOneShot(jumpSound);
        }
        
        if(inputHorizontal < 0)
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y);
    }
}
