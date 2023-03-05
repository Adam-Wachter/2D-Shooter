using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFireEnemy : MonoBehaviour
{
    //laser
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform spawnPoint;
    //fire rate
    [SerializeField]
    float bulletFireRate = 1;
    [SerializeField]
    float bulletSpeed = 10.0f;
    //variable to hold Time.time
    float lastShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireBullet();
    }

    void fireBullet()
    {

        if (Time.time > lastShot)
        {
            //update lastShot
            lastShot = Time.time + bulletFireRate;

            //Insantiate laser prefab
            GameObject projectile = Instantiate(bulletPrefab, spawnPoint.position + (spawnPoint.forward * .4f), spawnPoint.rotation);

            // Set the velocity of the projectile to be in the direction the spawn point is facing
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = spawnPoint.forward * bulletSpeed;
        }
    }
}
