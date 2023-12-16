using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuActivator : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPrefab;
    public bool pauseMenuOn = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenuOn)
        {
            pauseMenuOn = true;
            Instantiate(pauseMenuPrefab);
        }
    }
}
