using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderActivator : MonoBehaviour
{
    [SerializeField] Transform boulderFloor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boulderFloor.gameObject.SetActive(false);
        }
    }
}
