using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildTimer : MonoBehaviour
{

    [SerializeField] public float timer;
    [SerializeField] GameObject sheild; 

    // Start is called before the first frame update
    private void Awake()
    {
        timer = 5f; 
    }

    void Start()
    {
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <- 0  )
        {
            sheild.SetActive( false );
            timer = 5;
        }
    }
}
