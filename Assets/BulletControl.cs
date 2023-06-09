using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find all game objects with the tag "EnemyBullet"
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        // Loop through all the enemy bullets and ignore collision with them
        foreach (GameObject enemyBullet in enemyBullets)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemyBullet.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            // Destroy the bullet if it's outside the camera's view
            Destroy(gameObject);
        }
    }
}
