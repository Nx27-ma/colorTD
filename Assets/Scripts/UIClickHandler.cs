using System;
using System.Linq;
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
        panels = getDirectChildren(childAmount, canvas);
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

    GameObject[] getDirectChildren(int childAmount, GameObject parentObj)
    {
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

    public void towerSelect(GameObject type)
    {
        Instantiate(type);

    }

    enum PanelType
    {
        main, tower, exit
    }
}
