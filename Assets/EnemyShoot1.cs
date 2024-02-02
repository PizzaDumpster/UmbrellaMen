using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    [SerializeField] BulletSpeed bullet;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform[] shotPoints;
    [SerializeField] Transform shotCenter;
    [SerializeField] float shotCounter;
    [SerializeField] float timeBetweenShots; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //shotCenter.transform.rotation *= Quaternion.Euler( new Vector3(0,0,0.5f)); 
        shotCounter = shotCounter - Time.deltaTime; 
        if(shotCounter <= 0)
        {
            shotCounter = timeBetweenShots; 

            for(int i = 0; i < 4; i++)
            {
                Instantiate(enemyBullet, shotPoints[i].position, shotPoints[i].rotation);
                bullet = FindObjectOfType<BulletSpeed>();
                if(i == 0)
                {
                    bullet.Shoot(transform.right);
                }
                else if(i == 1)
                {
                    bullet.Shoot(-transform.right);
                }
                else if(i == 2)
                {
                    bullet.Shoot(transform.up);
                }
                else if(i == 3)
                {
                    bullet.Shoot(-transform.up);
                }
                    
            }
        }
    }
}
