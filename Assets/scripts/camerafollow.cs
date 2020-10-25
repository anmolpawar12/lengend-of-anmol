using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class camerafollow : MonoBehaviour
{
    [SerializeField] float smoothing = 5f;
    public Transform target;
    Vector3 offset;
   




    // Start is called before the first frame update
    void Start()
    {

        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newcampsoi = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newcampsoi, smoothing);
        
    }
    private void Awake()
    {
        Assert.IsNotNull(target);
    }
   
}
