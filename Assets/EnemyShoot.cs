using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;

    private float bulletMoveSpeed = 25f;
    private float timer = 0f;
    private float spawnInterval = 0.25f;
    private float moveSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // reset bullet timer
            timer = 0f;

            Vector3 enemyPos = transform.position;
            enemyPos.y = enemyPos.y - 5f;
            GameObject bullet = Instantiate(enemyBullet, enemyPos, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * bulletMoveSpeed;
        }
    }
}
