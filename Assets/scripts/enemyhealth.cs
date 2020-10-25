using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyhealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    private Animator ani;
    private float currentHealth;
    private ParticleSystem orcBlood;
    private NavMeshAgent nav;
    private  bool enemyalive ;
    private bool enemyDisapears = false;
    private AudioSource source;

    
    private CapsuleCollider capsule;
    private Rigidbody rb;
    public  bool enemyAlive
    {
        get { return enemyalive; }
    }
    
    
    
    private Animator heroani;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
        Gamemanager.instance.registerenemy(this);
        ani = GetComponent<Animator>();
        orcBlood = GetComponentInChildren<ParticleSystem>();
        nav = GetComponent<NavMeshAgent>();
        
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        enemyalive = true;
        source = GetComponent<AudioSource>();
        



        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDisapears == true)
        {
            transform.Translate(-Vector3.up * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Gamemanager.instance.gameOver)
        {
            if (other.tag == "hero")
            {
                takehit();
            }

        }
        
    }
    void takehit()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 10;
            ani.Play("hurt");
            source.PlayOneShot(source.clip);
            orcBlood.Play();

        }
        if (currentHealth <= 0)
        {
            
            
            enemyalive = false;
            
            killenemy();
            Gamemanager.instance.killedenemy(this);
        }
        print(currentHealth);
        

    }
    void killenemy()
    {
        nav.enabled = false;
        capsule.enabled = false;
        ani.Play("die");
        rb.isKinematic = true;
        StartCoroutine(enemyvanish());
        

    }
   IEnumerator enemyvanish()
   
   {
        yield return new WaitForSeconds(4f);
        enemyDisapears = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        
   }




}
