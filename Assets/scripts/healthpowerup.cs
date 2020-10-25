using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpowerup : MonoBehaviour
{
    private GameObject player;
    private playerHealth health;

     void Start()
    {
        player = Gamemanager.instance.hero;
        health = player.GetComponent<playerHealth>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            health.healthpowerup();
            Destroy(gameObject);
        }

      
    }
}
