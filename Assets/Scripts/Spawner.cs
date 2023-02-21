using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float reSpawnTime;

    private void Start()
    {
        StartCoroutine(spawner());
    }
    
    IEnumerator spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(reSpawnTime);
            spawnEnemy();
        }
    }
    void spawnEnemy()
    {
        int randomValue=Random.Range(0, enemy.Length);
        int randomXpos= Random.Range(-2, 2);
        Instantiate(enemy[randomValue], new Vector2(randomXpos,transform.position.y), Quaternion.identity);
    }
}
