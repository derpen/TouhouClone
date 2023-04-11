using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject circlePrefab;
    public float bulletDamage = 4f;

    private float moveSpeed = 150f;
    private float spawnInterval = 0.05f;
    private float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.touchCount > 0 && timer >= spawnInterval)
        {
            // reset bullet timer
            timer = 0f;

            Vector3 playerPos = transform.position;
            playerPos.y = playerPos.y + 5f;
            GameObject bullet = Instantiate(circlePrefab, playerPos, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.up * moveSpeed;
        }
    }
}
