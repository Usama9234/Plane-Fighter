using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public Transform gunpoint;
    public Transform gunpoint1;
    public float bulletFireTime;
    public GameObject playerBullet;
    public GameObject flash;
    public AudioSource audioSource;

    private void Start()
    {
        flash.SetActive(false);
        StartCoroutine(shoot());
    }

    void playerBulletFire()
    {
        Instantiate(playerBullet, gunpoint.transform.position, Quaternion.identity);
        Instantiate(playerBullet, gunpoint1.transform.position, Quaternion.identity);
    }
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletFireTime);
            playerBulletFire();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }


}
