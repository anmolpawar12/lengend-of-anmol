using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    private Transform player;
    private Animator ani;
    public float range = 3f;
    private bool playerInRange = false;
    private float timeafterattack = 1.5f;
    private BoxCollider[] weaponCollider;
    public ParticleSystem blood;
    private enemyhealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
        player = Gamemanager.instance.player.transform;
        ani = GetComponent<Animator>();
        weaponCollider = GetComponentsInChildren<BoxCollider>();
        enemyHealth = GetComponent<enemyhealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!Gamemanager.instance.gameOver && enemyHealth.enemyAlive )
        {
            if (Vector3.Distance(player.position, transform.position) < range)
            {
                playerInRange = true;

            }
            else
            {
                playerInRange = false;
            }


        }


    }
    IEnumerator attack()
    {
        if (playerInRange && !Gamemanager.instance.gameOver && enemyHealth.enemyAlive)
        {
            ani.Play("attack");
            blood.Play();


            yield return new WaitForSeconds(timeafterattack);

        }
        yield return null;
        StartCoroutine(attack());
    }
  public void enemystartattack()
    {
        foreach(var weapon in weaponCollider)
        {
            weapon.enabled = true;
        }
    }
    public void enemystopattack()
    {
        foreach (var weapon in weaponCollider)
        {
           
            weapon.enabled = false;
        }

    }
}

