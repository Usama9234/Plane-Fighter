using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position = transform.position+new Vector3(0, speed * Time.deltaTime,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
