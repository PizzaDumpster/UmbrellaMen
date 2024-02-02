using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 750f;
    public float maxLifetime = 10f;
    [SerializeField] AudioClip bulletSound; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        // The bullet only needs a force to be added once since they have no
        // drag to make them stop moving
        rb.AddForce(direction * speed);
        AudioManager.instance.Play("gun");
        // Destroy the bullet after it reaches it max lifetime
        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Sheild"))
        {
            rb.velocity = -rb.velocity * 3;
        }
        else
        {
            // what the fuck
            Destroy(gameObject);
        } 
    }

}