using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymove : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private enemyhealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = Gamemanager.instance.player.transform;
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        enemyHealth = GetComponent<enemyhealth>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.instance.gameOver && enemyHealth.enemyAlive)
        {
            nav.SetDestination(player.position);


        }
       else if(( Gamemanager.instance.gameOver || !Gamemanager.instance.gameOver ) && !enemyHealth.enemyAlive)
        {
            nav.enabled = false;
            ani.Play("idle");
        }
        else if (Gamemanager.instance.gameOver)
        {
           
            ani.Play("idle");

        }
    }
}
