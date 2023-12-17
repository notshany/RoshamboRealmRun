using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public Transform shootPoint; 
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ShootProjectile();
        }
    }
    
    void flip()
    {

    }
    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, transform.rotation); // spawn the projectile at the shootPoint
    }

}
