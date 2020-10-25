﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public float movespeed = 4f;
    public CharacterController controller;
    public Animator ani;
    public LayerMask layerMask;
    private Vector3 currentLookTarget = Vector3.zero;
    public Transform player;
    private Camera mainCamera;
    private BoxCollider[] weaponcollider;
    public GameObject fire;
    public ParticleSystem firethrower;
    public float playerspeed
    {
        get
        {
            return playerspeed;
        }
        set
        {
            value = movespeed;
        }

    }









    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        StartCoroutine(attack());
        weaponcollider = GetComponentsInChildren<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.instance.gameOver)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = Vector3.left * x + z * Vector3.forward;
            controller.Move(move * movespeed * Time.deltaTime);
            if (move == Vector3.zero)
            {
                ani.SetBool("iswalking", false);

            }
            else
            {
                ani.SetBool("iswalking", true);

            }

            if (Input.GetMouseButton(1))
            {

            }


        }










    }
    private void FixedUpdate()
    {
        if (!Gamemanager.instance.gameOver)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);

            if (Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.point != currentLookTarget)
                {
                    currentLookTarget = hit.point;
                }

                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            }


        }





    }
    IEnumerator attack()
    {
        if (!Gamemanager.instance.gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ani.Play("chop");
                yield return new WaitForSeconds(0.5f);

            }
            yield return null;
            StartCoroutine(attack());
        }
        
    }
    public void herostartattack()
    {
        foreach(var weapon in weaponcollider)
        {
            weapon.enabled = true;
        }
    }
    public void herostopattack()
    {
        foreach (var weapon in weaponcollider)
        {
            weapon.enabled = false;
        }
    }
    public void speedup()
    {
        StartCoroutine(speedpowerup());
    }
    IEnumerator speedpowerup()
    {
        fire.SetActive(true);
        movespeed=15f;
        yield return new WaitForSeconds(10f);
        movespeed = 8f;
        fire.SetActive(false);
       
        

        
    }
    


}
