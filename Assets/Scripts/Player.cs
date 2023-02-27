using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player move speed
    [SerializeField]
    int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //take current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerBoundries();
    }

    //movement code
    void playerMovement()
    {
        //Variables = input horizontal and vertical axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Variable = new position (horizontal input, vertical input, 0)
        Vector3 direction = new Vector3 (horizontalInput, verticalInput, 0);

        //Movement (in this direction * at this speed * in real time)
        transform.Translate (direction * speed * Time.deltaTime);
    }

    //player boundries
    void playerBoundries()
    {
        //preset boundries for x and y
        float yBoundryBottom = -4;
        float yBoundryTop = 5.9f;
        float xBoundryLeft = -11.3f;
        float xBoundryRight = 11.3f;

        //If player position on the Y is less than -4
        //Y = -4
        if (transform.position.y <= yBoundryBottom)
        {
            transform.position = new Vector3(transform.position.x, yBoundryBottom, transform.position.z);
        }

        //If player position on the Y is greater than 5.9
        //Y = 5.9
        if (transform.position.y >= yBoundryTop)
        {
            transform.position = new Vector3(transform.position.x, yBoundryTop, transform.position.z);
        }

        //If player position on the X is less than -11.3
        //set new position on X to 11.3
        if (transform.position.x < xBoundryLeft)
        {
            transform.position = new Vector3(xBoundryRight, transform.position.y, transform.position.z);
        }

        //If player position on the X is greater than 11.3
        //set new position on X to -11.3
        if (transform.position.x > xBoundryRight)
        {
            transform.position = new Vector3(xBoundryLeft, transform.position.y, transform.position.z);
        }
    }
}
