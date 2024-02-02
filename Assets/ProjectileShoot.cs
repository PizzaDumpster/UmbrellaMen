using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] BulletSpeed bullet;

    bool allowFire;

    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad myGamepad = Gamepad.current; 
        if (myGamepad != null)
        {
            if (myGamepad.rightTrigger.isPressed && allowFire)
            {
                StartCoroutine(FireRate());
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && allowFire)
            {
                StartCoroutine(FireRate());
            }
        }

    }
    IEnumerator FireRate()
    {
        allowFire = false;
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        bullet = FindObjectOfType<BulletSpeed>();
        bullet.Shoot(transform.right);
        yield return new WaitForSeconds(0.125f);
        allowFire = true;
    }

}
