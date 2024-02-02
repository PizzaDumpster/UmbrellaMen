using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] GameObject player;
    [SerializeField] GameObject turret;
    [SerializeField] bool canShoot;
    [SerializeField] BulletSpeed bullet;
    [SerializeField] AudioClip bulletSound;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(turret.transform.position, player.transform.position);
            if (distanceToPlayer <= 20.0f)
            {
                var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
                newRotation.x = 0.0f;
                newRotation.y = 0.0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 8);
            }
            if (distanceToPlayer <= 20)
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot());
                }

            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 8);
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;

        Instantiate(enemyBullet, firePoint.transform.position, Quaternion.identity);
        bullet = FindObjectOfType<BulletSpeed>();
        bullet.Shoot(transform.up);
        AudioManager.instance.PlaySound(bulletSound);
        float myRandomNumber = Random.Range(0.5f, 3f);
        yield return new WaitForSeconds(myRandomNumber);
        canShoot = true;
    }
}
