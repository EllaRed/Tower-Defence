using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour
{
    //the tower to be built
    public GameObject towerPrefab;
   
  
   void OnMouseUpAsButton() {
    //Build tower above Buildplace

    GameObject g = (GameObject)Instantiate(towerPrefab);
    g.transform.position=transform.position+ Vector3.up;

   }
}
