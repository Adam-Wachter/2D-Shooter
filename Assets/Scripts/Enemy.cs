using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    GameObject player;

    Vector3 playerPosition;

    //[SerializeField]
    //float enemySpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
        enemyFire();
        lookAtPlayer();
    }

    //enemy movement
    void enemyMovement()
    {
        playerPosition = player.transform.position;

        //transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        agent.SetDestination(playerPosition);

    }

    //look at player
    void lookAtPlayer()
    {
        transform.LookAt(playerPosition);
    }

    //enemy fire
    void enemyFire()
    {
        
    }
}
