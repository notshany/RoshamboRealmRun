
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class WinGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player enter");
            SceneManager.LoadScene(4);
        }
    }
}