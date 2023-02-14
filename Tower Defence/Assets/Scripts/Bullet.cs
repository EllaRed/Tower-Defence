using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=10;

    public Transform target;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
    {
        Vector3 dir =target.position-transform.position;
        GetComponent<Rigidbody>().velocity=dir.normalized*speed;
    
    }else{

        Destroy(gameObject);
    }
        
    }

    void OnTriggerEnter(Collider other) {
        Health health =other.GetComponentInChildren<Health>();
        if (health){
            health.Decrease();
            Destroy(gameObject);
        }
    }
}
