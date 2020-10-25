using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedpowerup : MonoBehaviour
{
    private GameObject player;
    private movement speed;
    // Start is called before the first frame update
    void Start()
    {
        player = Gamemanager.instance.hero;
        speed = player.GetComponent<movement>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            speed.speedup();
            Destroy(gameObject);
        }
    }
}
