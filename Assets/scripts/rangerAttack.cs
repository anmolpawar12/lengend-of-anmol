using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangerAttack : MonoBehaviour
{
    private Transform player;
    private Animator ani;
    public float range = 3f;
    private bool playerInRange = false;
    private float timeafterattack = 1.5f;
    public Transform fireLocation;
    
    public ParticleSystem blood;
    private enemyhealth enemyHealth;
    private GameObject arrow;
        

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
        player = Gamemanager.instance.player.transform;
        ani = GetComponent<Animator>();
      
        enemyHealth = GetComponent<enemyhealth>();
        arrow = Gamemanager.instance.Arrow;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.instance.gameOver && enemyHealth.enemyAlive)
        {
            if (Vector3.Distance(player.position, transform.position) < range)
            {
                playerInRange = true;
                rangerRotate(player);

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
    void rangerRotate(Transform player)
    {
        Vector3 direction = (player.position-transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }
   public void fireArrow()
    {
        GameObject newArrow = Instantiate(arrow) as GameObject;
        newArrow.transform.position = fireLocation.position;
        newArrow.transform.rotation = transform.rotation;
        newArrow.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
       



    }
    
}

