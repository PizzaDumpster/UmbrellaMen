using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] AudioClip explosion;
    [SerializeField] GameObject bomb;
   

    private void Awake()
    {
       
        bomb = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("bomb");
        Collider2D[] bombExplostion = Physics2D.OverlapCircleAll(bomb.transform.position, 10f);
        foreach(Collider2D hit in bombExplostion) 
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<EnemyHealth>().health = 0;
                ScoreTracker.instance.score += 100; 
            }
            if (hit.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(hit.gameObject);
                ScoreTracker.instance.score += 100;
            }
        }
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
