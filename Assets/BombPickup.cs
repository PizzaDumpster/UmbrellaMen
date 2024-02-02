using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    MovementController myMovementController; 

    // Start is called before the first frame update
    void Start()
    {
        myMovementController = GameObject.FindWithTag("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myMovementController.bombCounter++;
            gameObject.SetActive(false);
        }

    }
}
