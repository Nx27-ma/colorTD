using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    private GameObject path;
    private GameObject[] pathChildren;
   
    void Start()
    { 
        path = GameObject.FindWithTag("PathPoints");
        pathChildren = UIClickHandler.getDirectChildren(path);
            
    }

}
