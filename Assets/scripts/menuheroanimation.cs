using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuheroanimation : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine(heroanimation());

    }

    IEnumerator heroanimation()
    {
        ani.Play("idle");
        yield return new WaitForSeconds(4f);
        ani.Play("chop");
        yield return new WaitForSeconds(4f);
        ani.Play("shin attack");
        yield return new WaitForSeconds(4f);
        ani.Play("walk");
        StartCoroutine(heroanimation());
    }
}
