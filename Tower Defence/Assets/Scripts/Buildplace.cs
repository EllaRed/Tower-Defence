using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour
{
    //the tower to be built
    public GameObject towerPrefab;
   
    private bool towerBuilt = false;

    void OnMouseUpAsButton() {
        //Check if a tower has been built already
        if (towerBuilt) {
            return; 
        }

        //Build tower above Buildplace
        GameObject g = (GameObject)Instantiate(towerPrefab);
        g.transform.position=transform.position+ Vector3.up;

        towerBuilt=true;

    }
}