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
    Button[] buttonsTemp;
    Button[] buttons;
    public GameObject SelectedGameObject;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        panels = Utils.getDirectChildren(canvas);
        Type buttonType = typeof(Button);
        buttonsTemp = Utils.getAllChildrenOfType<Button>(panels[(int)PanelType.main]);
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

    public void panelBasedActions(GameObject buttonPressed)
    {
        SelectedGameObject = Instantiate( buttonPressed);
    }

    enum PanelType
    {
        main, tower, exit
    }
}
