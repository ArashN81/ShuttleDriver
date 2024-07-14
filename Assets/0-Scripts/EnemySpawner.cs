using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 10f;
    private float timer = 0;
    public float highOffset = 10;
    public float lowOffset = 10;
    public Vector3 enemySize;
    public float randSize = 1f;
    public float gTimer = 0f;

    private void Start()
    {
        gTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameTimer();
       

            if (timer < spawnRate)
            {
                timer += Time.fixedDeltaTime;
            }
            else
            {
                SpawEnemy();
                timer = 0;
            }
        randSize = Random.Range(0.5f, 1.2f);
    }

    void SpawEnemy()
    {
        float lowestPoint = transform.position.y - lowOffset;
        float highestPoint = transform.position.y + highOffset;
        EnemyInf();
        
        Instantiate(enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        

    }


    public void EnemyInf()
    {
        enemy.transform.localScale = new Vector3(randSize, randSize, 1);
        enemySize = enemy.transform.localScale;
    }

    public void GameTimer()
    {
        gTimer += Time.deltaTime;
        Debug.Log(timer.ToString());
        if (gTimer < 2)
        {
            spawnRate = 1f;
        }
        else if (gTimer > 3 && gTimer < 10)
        {
            spawnRate = 0.8f;
        }
        else if (gTimer > 10 && gTimer < 50)
        {
            spawnRate = 0.5f;
        }
        else if (gTimer > 50 && gTimer < 100)
        {
            spawnRate = 0.3f;
        }
        else if (gTimer > 100)
        {
            spawnRate = 0.18f;
        }
    }
}
