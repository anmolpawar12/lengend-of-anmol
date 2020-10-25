using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuanimation : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine(startanimation());
        
    }

    IEnumerator startanimation()
    {
        ani.Play("idle");
        yield return new WaitForSeconds(4f);
        ani.Play("attack");
        yield return new WaitForSeconds(4f);
        ani.Play("walk");
        yield return new WaitForSeconds(4f);
        StartCoroutine(startanimation());
        
    }
}
