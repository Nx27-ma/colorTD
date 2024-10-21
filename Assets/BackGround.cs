using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] GameObject towerPanel;
    [SerializeField] GameObject backGround;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(towerPanel.activeInHierarchy== true)
        {
            backGround.SetActive(true);
        }
       else
        {
            backGround.SetActive(false);
        }
    }
}
