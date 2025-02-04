using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;
    public int damage;
    public GameObject hitEffect;
    
    private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().takeDamage(damage);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (other.tag == "Ground")
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        GameObject.Destroy(this.gameObject);
        
    }
}
