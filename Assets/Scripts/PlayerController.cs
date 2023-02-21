using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public CoinCount coinCount;
    public GameObject explosion;
    public PlayerHealthBar playerHealthBar;
    public float padding = 0.5f;
    public float speed;
    public Transform playerPos;
    float minX;
    float maxX;
    float minY;
    float maxY;

    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;
    

    public GameObject damageEffect;

    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;

    private void Start()
    {
        findBoundaries();
        damage = barFillAmount / health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "EnemyBullet") 
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            damageHealthBar();
            Destroy(collision.gameObject);
            
            GameObject Vfx = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(Vfx, 0.05f);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject VFX = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(VFX, 2f);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                gameController.gameOver();
            }
        }
        if (collision.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
            Destroy(collision.gameObject);
            coinCount.addCount();
        }
    }
    public void damageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.setAmount(barFillAmount);
        }
    }

    void findBoundaries()//finding boundaries for clamp
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;

    }
    void Update()//Getting Input from user
    {
        float deltaX = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float newPosX= Mathf.Clamp(transform.position.x + deltaX,minX,maxX);

        float deltaY = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        float newPosY = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);
        transform.position = new Vector2(newPosX, newPosY);
    }
}
