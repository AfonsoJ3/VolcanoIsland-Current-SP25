using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    private float input;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input=Input.GetAxisRaw("Horizontal");
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
    }

    public void takeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            //play a sound
            //show the gameover screen
            //play a particle system
            //spawn other things
            this.gameObject.SetActive(false);
        }
    }
    
}
