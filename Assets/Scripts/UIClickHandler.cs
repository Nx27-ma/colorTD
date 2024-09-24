using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIClickHandler : MonoBehaviour
{
    //Set all panels on inactive except main

    GameObject canvas;
    GameObject[] panels;
    GameObject[] buttonsTemp;
    Button[] buttons;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        int childAmount = canvas.transform.childCount;
        panels = getDirectChildren(canvas);
        Type buttonType = typeof(Button);
        buttonsTemp = getAllChildrenOfType(panels[(int)PanelType.main], buttonType);
        getButtons();
    }

    void getButtons()
    {
        buttons = new Button[buttonsTemp.Length];
        for (int i = 0; i < buttonsTemp.Length; i++)
        {
            buttons[i] = buttonsTemp[i].gameObject.GetComponent<Button>();
        }

    }

    public static GameObject[] getDirectChildren(GameObject parentObj, int amount = 0)
    {
        int childAmount = parentObj.transform.childCount;
        if (amount != 0)
        {
            childAmount = amount;
        }
        GameObject[] children = new GameObject[childAmount];

        for (int i = 0; i < childAmount; i++)
        {
            children[i] = parentObj.transform.GetChild(i).gameObject;
        }

        return children;
    }

    GameObject[] getChildrenByName(string[] names, GameObject parentObj)
    {
        GameObject[] children = new GameObject[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            children[i] = parentObj.transform.Find(names[i]).gameObject;
            if (names[i] != null)
            {
                Debug.Log("Warning no name found at index:" + i);
            }
        }

        return children;
    }


    GameObject[] getAllChildrenOfType(GameObject parentObj, Type type)
    {
        GameObject[] filtered = parentObj.transform.GetComponentsInChildren(type)
                  .Select(i => i.gameObject)
                  //.Take(childAmount)
                  .ToArray();
        Debug.Log(filtered.Length);
        return filtered;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addListenerToButtons()
    {

        for (int i = 0; buttons.Length > 0; i++)
        {
            buttons[i].onClick.AddListener(buttonPressed);
        }

    }

    void buttonPressed()
    {
        bool pressed = true;


    }





    enum PanelType
    {
        main, tower, exit
    }
}
