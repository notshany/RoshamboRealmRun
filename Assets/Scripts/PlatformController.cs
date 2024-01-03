using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2.0f;
    public float UpBound = 8.0f;
    public float DownBound = -4.0f;
    public bool isMovingUp = true;
    private Transform platformTransform;

    void Start()
    {
        platformTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isMovingUp)
        {
            platformTransform.Translate(Vector2.up * speed * Time.deltaTime);
            if (platformTransform.position.y >= UpBound)
            {
                isMovingUp = false;
            }
        }
        else
        {
            platformTransform.Translate(Vector2.down * speed * Time.deltaTime);
            if (platformTransform.position.y <= DownBound)
            {
                isMovingUp = true;
            }
        }
    }

}
