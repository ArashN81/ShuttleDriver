using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 38f;
    public float deadZone = -20;
    public float gTimer = 0f;
    void FixedUpdate()
    {
        GameTimer();
        transform.position = transform.position + (moveSpeed * Time.fixedDeltaTime * Vector3.left);
        
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
    public void GameTimer()
    {
        gTimer += Time.deltaTime;


        if (gTimer > 10 && gTimer < 50)
        {
            moveSpeed += 0.1f;
        }
        else
        {
            moveSpeed += 0.5f;
        }
    }

}
