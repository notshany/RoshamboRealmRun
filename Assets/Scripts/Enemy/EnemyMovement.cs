using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;

    private void Update()
    {
        float horizontalMovement = Mathf.PingPong(Time.time * speed, range * 2) - range; // 
        transform.position = new Vector2(horizontalMovement, transform.position.y);
    }
}
