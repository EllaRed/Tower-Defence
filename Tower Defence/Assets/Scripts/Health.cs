using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    TextMesh tm;
    void Start()
    {
        tm=GetComponent<TextMesh>();
    }

    
    void Update()
    {
        //Always face the camera
        transform.forward= Camera.main.transform.forward;
    }

    public int currentHealth(){
        return tm.text.Length;
    }

    //Decrease the current health by removing one '-'
    public void Decrease(){
        if(currentHealth()>1)
        tm.text=tm.text.Remove(tm.text.Length-1);
        else
        Destroy(transform.parent.gameObject);

    }

}
