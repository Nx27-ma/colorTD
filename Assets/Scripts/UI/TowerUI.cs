using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public GameObject frame;
    void Start()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        frame.transform.position = Camera.main.WorldToScreenPoint(transform.position); 
    }
}
