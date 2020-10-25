﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float startingHealth = 100f;
    public Animator ani;
    private float timer = 0f;
    private float attackdelay = 2f;
    private float currenthealth;
    public Slider slider;
    private AudioSource source;
 
    
    
    public float currentHealth
    {
        get
        {
            return currenthealth;
        }
        set
        {
            if (value < 0)
            {
                currenthealth = 0;
            }
            else
            {
                currenthealth = value;
            }
        }
    }


    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = startingHealth;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(timer>attackdelay && !Gamemanager.instance.gameOver)
        {
            if (other.tag == "wapeon")
            {
                currentHealth -= 10;
                
                ani.Play("hurt");
                source.PlayOneShot(source.clip);

                slider.value = currenthealth;
                print(currentHealth);
               
                if (currenthealth <= 0)
                {
                    Gamemanager.instance.playerIsDead();
                    ani.Play("die");
                }


            }
            timer = 0f;
            

        }
        
    }
   public void healthpowerup()
    {
        if (currenthealth< 70)
        {
            currentHealth += 30;
        }
        else if(currenthealth<startingHealth)
        {
            currentHealth = startingHealth;
            
        }
        slider.value = currentHealth;
        print(currentHealth);
    }
   
  

}
