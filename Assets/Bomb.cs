using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{

    [SerializeField] float timer;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject parachute;
    [SerializeField] GameObject blastWave;
    
    // Start is called before the first frame update
    void Awake()
    {
         
        timer = 2.5f; 
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad myGamepad = Gamepad.current;
        Keyboard myKeyboard = Keyboard.current;

        if (myGamepad != null) 
        {
            if (myGamepad.rightShoulder.wasPressedThisFrame)
            {
                timer = 0;
           
            }
        }

        if (myKeyboard != null)
        {
            if (myKeyboard.leftCtrlKey.wasPressedThisFrame)
            {
                timer = 0; 
            
            }
        }

        timer = timer - Time.deltaTime;

        if(timer <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(blastWave, transform.position, Quaternion.identity);
            Destroy(parachute);
        }

    }
}
