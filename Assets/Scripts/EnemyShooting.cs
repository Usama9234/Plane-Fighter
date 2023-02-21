using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform []gunPoint;
    public GameObject damageEffect;
    public HealthBar healthbar;
    public GameObject flash;
    public GameObject enemyBullet;
    public GameObject coin;
    
    public float gunFireTime;
    public GameObject explosion;
    public float health = 10f;
    public float barSize = 1f;
    public float damage = 0;
    public float speed=-1f;

    public AudioClip bulletClip;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;


    private void Start()
    {
        
        flash.SetActive(false);
        StartCoroutine(shoot());
        damage = barSize / health;
    }
    private void Update()
    {
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            damageHealthBar();
            Destroy(collision.gameObject);
            
            GameObject vfx = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(vfx, 0.05f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject);
                GameObject Exp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(Exp, .4f);
                Instantiate(coin, transform.position, Quaternion.identity);
                
                
            }
        }
    }
    void damageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.setSize(barSize);

        }
    }
    void fire()
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].transform.position, Quaternion.identity);
        }
        //Instantiate(enemyBullet, gunPoint.transform.position, Quaternion.identity);
        //Instantiate(enemyBullet, gunPoint1.transform.position, Quaternion.identity);
    }
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(gunFireTime);
            fire();
            audioSource.PlayOneShot(bulletClip, 0.5f);
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }

}
