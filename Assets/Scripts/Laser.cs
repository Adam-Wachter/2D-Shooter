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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserMovement();
        laserTimeout();
    }

    void laserMovement()
    {
        //Move the laser up at a set speed
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
    }

    void laserTimeout()
    {
        //destroy laser after a set time
        Destroy(this.gameObject, laserFlightTime);
    }
}
