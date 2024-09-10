using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIClickHandler : MonoBehaviour
{
    GameObject canvas;
    GameObject[] panels;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        int childAmount = canvas.transform.childCount;
        panels = initChildren(childAmount, canvas);
    }

    GameObject[] initChildren(int childAmount, GameObject currentObj)
    {
        GameObject[] children = new GameObject[childAmount];

        for (int i = 0; i < childAmount; i++)
        {
            children[i] = currentObj.transform.GetChild(i).gameObject;
        }

        return children;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void towerButton()
    {
        Onclick.addlistern(funcite);
    }







    enum PanelType
    {
        main, tower, exit
    }
}
