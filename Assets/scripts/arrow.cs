using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        
        
        
       Destroy(gameObject);
        

    }

}
