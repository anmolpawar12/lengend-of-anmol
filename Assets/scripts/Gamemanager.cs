﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance = null;
    private bool gameactive = false;
    private bool gameover = false;
    public GameObject[] spwanpoints;
    public GameObject[] prefebs;
    private List<enemyhealth> enimesalive = new List<enemyhealth>();
    private List<enemyhealth> enimeskilled = new List<enemyhealth>();
    public Text currentlevel;
    private float currentLevel = 1f;
    private float genratedtime = 0f;
    private float spwantime = 2f;
    private GameObject newEnemy;
    public Transform player;
    public GameObject arrow;
    public GameObject hero;
    public GameObject healthpowerup;
    private float currenthealthup =0f;
    public GameObject speedpowerup;
    private float currentspeedup=0f;
    public float finallevel = 20f;
    public Text endgametext;
    

    
    public Transform[] healthupposition;
    public Transform[] speedposition;

    

    public void registerenemy(enemyhealth enemy)
    {
        enimesalive.Add(enemy);
    }
    public void killedenemy(enemyhealth enemy)
    {
        enimeskilled.Add(enemy);
    }
    public GameObject Arrow
    {
        get { return arrow; }
    }
  
    
    public bool gameOver
    {
        get { return gameover; }
    }
    public bool gameActive
    {
        get { return gameactive; }
    }
  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {

        StartCoroutine(spawnenemy());
        StartCoroutine(powerup());
        StartCoroutine(speedup());
        endgametext.GetComponent<Text>().enabled = false;
       

    }

   
    void Update()
    {
        genratedtime += Time.deltaTime;
        
    }
    public void playerInGame()
    {
        gameactive = true;

    }
   
    public void playerIsDead()
    {
        
        gameover = true;
        StartCoroutine(endgame("YOU LOST"));
    }
    IEnumerator spawnenemy()
    {
        if (spwantime<genratedtime )
        {
            genratedtime = 0f;
            if (enimesalive.Count < currentLevel * 2)
            {
                int enemynumber = Random.Range(0, 3);
                
                GameObject spwanPlace = spwanpoints[Random.Range(0, 3)];
                if (enemynumber == 0)
                {
                     newEnemy = Instantiate(prefebs[0]) as GameObject;

                }
                else if (enemynumber == 1)
                {
                    newEnemy = Instantiate(prefebs[1]) as GameObject;
                    
                }
                else if (enemynumber == 2)
                {
                    newEnemy = Instantiate(prefebs[2]) as GameObject;
                }
                newEnemy.transform.position = spwanPlace.transform.position;

                
                
            }
            if (enimeskilled.Count == currentLevel*2 && currentLevel!=finallevel)
            {
                enimesalive.Clear();
                enimeskilled.Clear();
                yield return new WaitForSeconds(3f);
                currentLevel++;
               
                 currentlevel.text = "LEVEL  " + currentLevel;
                 currenthealthup = 0f;
                currentspeedup = 0f;
            }
            if (currentLevel==finallevel)
            {
                StartCoroutine(endgame("victory"));
            }
        }
        yield return null;
        StartCoroutine(spawnenemy());

    }
    IEnumerator powerup()
    {
        yield return new WaitForSeconds(20f);
        if ( currenthealthup<3 )
        {
            GameObject healthup = Instantiate(healthpowerup) as GameObject;
            healthup.transform.position = healthupposition[Random.Range(0, 2)].position;
            currenthealthup++;
            yield return new WaitForSeconds(20f);



        }
        yield return null;
        StartCoroutine(powerup());
    }
    IEnumerator speedup()
    {
        yield return new WaitForSeconds(10f);
        if (currentspeedup < 3)
        {
            GameObject speed = Instantiate(speedpowerup) as GameObject;
            speed.transform.position = speedposition[Random.Range(0, 2)].position;
            currentspeedup ++;
            yield return new WaitForSeconds(10f);

        }
        yield return null;
        StartCoroutine(speedup());
    }
    IEnumerator endgame(string outcome)
    {
        endgametext.text = outcome;
        endgametext.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("mainMenu");
        
    }
}
