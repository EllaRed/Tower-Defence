using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=10;

    //target set by tower
    public Transform target;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
    {
        Vector3 direction =target.position-transform.position;
        //move towards target
        GetComponent<Rigidbody>().velocity=direction.normalized*speed;
    
    }else{

        Destroy(gameObject);
    }
        
    }

    //when bullet hits target, decrease health
    void OnTriggerEnter(Collider co) {
        Health health =co.GetComponentInChildren<Health>();
        if (health){
            health.Decrease();
            Destroy(gameObject);
        }
    }
}
