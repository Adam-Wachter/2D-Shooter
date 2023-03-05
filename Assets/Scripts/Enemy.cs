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

    public int maxHealth = 1;
    private int currentHealth;
    public float deathDelay = 1f;
    public Animator animator;

    //[SerializeField]
    //float enemySpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //enemyMovement();
        //enemyFire();
        //lookAtPlayer();
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, deathDelay);
        }
    }
}
