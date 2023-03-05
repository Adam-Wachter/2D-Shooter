using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //laser travel speed
    [SerializeField]
    float laserSpeed = 10.0f;
    //laser flight time
    [SerializeField]
    float laserFlightTime = 1.0f;
    public int damage = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //laserMovement();
        laserTimeout();
    }

    void laserMovement()
    {
        //Move the laser up at a set speed
        transform.Translate(Vector3.forward * laserSpeed * Time.deltaTime);
    }

    void laserTimeout()
    {
        //destroy laser after a set time
        Destroy(this.gameObject, laserFlightTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.GetComponent<Enemy>().TakeDamage(damage);
            //enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            other.transform.GetComponent<Player>().TakeDamage(damage);
            //player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
