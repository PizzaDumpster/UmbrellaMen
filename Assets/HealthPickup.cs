using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth myPlayerHealth;
    [SerializeField] AudioClip healthSound; 

    // Start is called before the first frame update
    void Start()
    {
        myPlayerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            myPlayerHealth.health += 1;
            this.gameObject.SetActive(false);
            //AudioManager.instance.PlaySound(healthSound);
            AudioManager.instance.Play("health");

        }
    }
}
