using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour

{
    public bool isCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            gameObject.SetActive(false); // hides the object
        }
    }
}

