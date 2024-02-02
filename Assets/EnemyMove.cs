using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject movePointA;
    [SerializeField] GameObject movePointB;
    [SerializeField] bool movingRight;
    [SerializeField] bool movingLeft;
    [SerializeField] float moveRate; 

    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = movePointA.transform.position;
        movingRight = true;
        movingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            if (enemy.transform.position.x <= movePointB.transform.position.x && movingRight)
            {
                enemy.transform.position += new Vector3(moveRate, 0, 0);
                if (enemy.transform.position.x >= movePointB.transform.position.x)
                {
                    movingLeft = true;
                    movingRight = false;
                }
            }
            if (enemy.transform.position.x >= movePointA.transform.position.x && movingLeft)
            {
                enemy.transform.position += new Vector3(-moveRate, 0, 0);
                if (enemy.transform.position.x <= movePointA.transform.position.x)
                {
                    movingLeft = false;
                    movingRight = true;
                }
            }

        }
    }
}
