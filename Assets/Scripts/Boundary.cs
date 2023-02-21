using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDestroyer"||collision.tag=="EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
