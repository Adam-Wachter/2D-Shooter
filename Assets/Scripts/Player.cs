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
}
