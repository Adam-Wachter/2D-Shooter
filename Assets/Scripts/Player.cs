using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player move speed
    [SerializeField]
    int speed = 1;
    //laser
    [SerializeField]
    GameObject laserPrefab;
    //fire rate
    [SerializeField]
    float laserFireRate = 1;
    //variable to hold Time.time
    float lastShot = 0.0f;
    Camera m_camera;

    // Start is called before the first frame update
    void Start()
    {
        //call camera
        m_camera = Camera.main;

        //take current position = new position (0,0,0)
        //transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //playerMovement();
        //lookAtMouse();
        playerBoundries();
        //fireLaser();
    }

    //look at mouse
    void lookAtMouse()
    {
        Vector3 lookAtPos = Input.mousePosition;
        lookAtPos.z = m_camera.transform.position.y - transform.position.y;
        lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
        transform.forward = lookAtPos - transform.position;
    }

    //movement code
    void playerMovement()
    {
         //Variables = input horizontal and vertical axis
         float horizontalInput = Input.GetAxis("Horizontal");
         float verticalInput = Input.GetAxis("Vertical");

         //Variable = new position (horizontal input, vertical input, 0)
         Vector3 direction = new Vector3 (horizontalInput, 0, verticalInput);

         //Movement (in this direction * at this speed * in real time)
         transform.Translate (direction * speed * Time.deltaTime); 

        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }*/

    }

    //player boundries
    void playerBoundries()
    {
        //preset boundries for x and y
        float yBoundryBottom = -10.12f;
        float yBoundryTop = 10.12f;
        float xBoundryLeft = -18.4f;
        float xBoundryRight = 18.4f;

        //If player position on the Y is less than or equal to -4
        //Y = -4
        if (transform.position.z <= yBoundryBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yBoundryBottom);
        }

        //If player position on the Y is greater than or equal to 5.9
        //Y = 5.9
        if (transform.position.z >= yBoundryTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yBoundryTop);
        }

        //If player position on the X is less than -11.3
        //set new position on X to 11.3
        if (transform.position.x <= xBoundryLeft)
        {
            transform.position = new Vector3(xBoundryLeft, transform.position.y, transform.position.z);
        }

        //If player position on the X is greater than 11.3
        //set new position on X to -11.3
        if (transform.position.x >= xBoundryRight)
        {
            transform.position = new Vector3(xBoundryRight, transform.position.y, transform.position.z);
        }
    }

    //player fires laser
    void fireLaser()
    {
        //If the right amount of time has passed since the last shot and space key is hit
        //spawn laser prefab
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > laserFireRate+lastShot)
        {
            //update lastShot
            lastShot = Time.time + laserFireRate;

            //Insantiate laser prefab
            Instantiate(laserPrefab, transform.position + (transform.forward * .7f), Quaternion.identity);
        }
        
    }
}
