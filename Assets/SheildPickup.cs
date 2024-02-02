using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPickup : MonoBehaviour
{

    [SerializeField] GameObject sheild;
    SheildTimer mySheildTimer;

    // Start is called before the first frame update
    void Start()
    {
        mySheildTimer = sheild.GetComponent<SheildTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && sheild != null)
        {
            sheild.SetActive(true);
            mySheildTimer.timer = 5; 
            gameObject.SetActive(false);
        }
        
    }
}
