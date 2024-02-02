using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] AudioClip explosion;
    [SerializeField] PlayerHealth myHealth; 

    // Start is called before the first frame update
    void Start()
    {
        myHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            AudioManager.instance.Play("ouch");
            ScoreTracker.instance.IncrementScore(100);
            Destroy(collision.gameObject); 
            health--; 
        }
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.Play("ouch");
            myHealth.health -= 1; 
        }
      
    }
}
