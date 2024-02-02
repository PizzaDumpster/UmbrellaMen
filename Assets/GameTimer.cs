using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameTimer : MonoBehaviour
{

    [SerializeField] public float gameTimer;
    [SerializeField] public float timeCounter; 

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 120f; 
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        gameTimer -= Time.deltaTime;
        if(gameTimer <= 0f)
        {
            GameManager.instance.isPopUp = true;
            
        }
    }
}
