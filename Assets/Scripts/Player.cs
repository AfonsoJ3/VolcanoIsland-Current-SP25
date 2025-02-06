using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    private float input;
    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input=Input.GetAxisRaw("Horizontal");
        if (input > 0 || input < 0)
        {
            anim.SetBool("isRunning",true);
        }
        if (input == 0)
        {
            anim.SetBool("isRunning",false);
        }


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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input * speed, rb.linearVelocity.y);
    }

    public void reset()
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
