using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    private float bulletMoveSpeed = 35f;
    
    private float shootInterval = 4f;
    private float sessionInterval = 3f;

    private float timerShoot = 0f;
    private float timerSession = 0f;

    // Start is called before the first frame update
    void Start()
    {
       timerShoot = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timerShoot += Time.deltaTime;

        // Check if it's time to shoot
        if (timerShoot >= shootInterval)
        {
            timerSession += Time.deltaTime;

            // Check if it's time to stop shooting
            if (timerSession >= sessionInterval)
            {
                timerSession = 0f;
                timerShoot = 0f;
            }
            else
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector3 enemyPos = transform.position;
        enemyPos.y = enemyPos.y - 5f;
        GameObject bullet = Instantiate(enemyBullet, enemyPos, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletMoveSpeed;
    }
}
