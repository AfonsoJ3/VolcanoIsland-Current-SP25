using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;
    
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
}
