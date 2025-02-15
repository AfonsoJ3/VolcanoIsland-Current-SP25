using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    private float input;
    private Rigidbody2D rb;
    private Animator anim;

//PA1 -> Dash Variables
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f;
    public float dashCooldown = 3f;
    private float dashCounter;
    private float dashCoolCounter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        activeMoveSpeed = speed;
        Debug.Log("hello");

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input > 0 || input < 0)
        {
            anim.SetBool("isRunning",true);
        }
        if (input == 0)
        {
            anim.SetBool("isRunning",false);
        }

//Turn the player left or right
        if (input > 0)
        {
            //right
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (input < 0)
        {
            //left
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
           //Debug.Log("Space pressed!");
            if (dashCoolCounter <=0 && dashCounter <=0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                //Debug.Log("dashCounter and dashCoolCounter are less then 0");
            }   
        }

        if (dashCounter > 0)
        {
            //Debug.Log("dashCounter > 0");
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
                Debug.Log("dashCounter <= 0");
            }
        }

        if(dashCoolCounter > 0)
        {
            Debug.Log("dashCoolCounter > 0");
            dashCoolCounter -=  Time.deltaTime;
        }


    }

    void FixedUpdate()
    {
        //rb.linearVelocity = new Vector2(input * speed, rb.linearVelocity.y);
        if (dashCounter > 0) 
        {
            rb.linearVelocity = new Vector2(transform.right.x * dashSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(input * activeMoveSpeed, rb.linearVelocity.y);
        }
    }

    public void Reset()
    {
        health = 3;
        Vector3 pos = new Vector3(0f,-4.11f,0f);
        transform.position = pos;
        this.gameObject.SetActive(true);
        GameManager.instance().setDeathCanvas(false);
        GameManager.instance().updateHealthText(health);
    }

    public void takeDamage(int value)
    {
        health -= value;
        GameManager.instance().updateHealthText(health);
        if (health <= 0)
        {
            //play a sound
            //show the gameover screen
            //play a particle system
            //spawn other things
            this.gameObject.SetActive(false);
            GameManager.instance().setDeathCanvas(true);
        }
    }
    
}
