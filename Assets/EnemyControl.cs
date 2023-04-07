using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private float health = 100f;
    private float bulletDamage; // player bullet
    private float moveSpeed = 25f;

    // TODO
    // this is already called in EnemySpawner, call this just once
    private float cameraHeight;
    private float cameraWidth;

    private bool isMovingLeft = true;

    // TODO
    // Might put this in another script to only call it once
    private float leftEdge;
    private float rightEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get bullet damage
        // Will change later so it can handle different bullet types
        ShootBullets shootBullets = FindObjectOfType<ShootBullets>();
        if (shootBullets != null)
        {
            bulletDamage = shootBullets.bulletDamage;
        }
        else
        {
            Debug.LogError("ShootBullets script not found!");
        }

        cameraHeight = Camera.main.orthographicSize * 2f;
        leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        // This enemy won't move beyond 75% (roughly) of screen width
        // TODO, get a more consistent way to do this
        if (transform.position.y >= Camera.main.transform.position.y - cameraHeight * -0.2f)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else
        {
            if(isMovingLeft == true)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                if(transform.position.x <= leftEdge)
                {
                    isMovingLeft = false;
                }
            }
            else
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                if(transform.position.x >= rightEdge)
                {
                    isMovingLeft = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);

            // Damage the enemy or destroy it
            health -= bulletDamage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
}
}
