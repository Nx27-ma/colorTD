using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PlayerInterface : MonoBehaviour
{
    GameObject canvas;
    GameObject[] displayFields;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        string[] names = { "Money", "Lives" };
        displayFields = FindChildren.GetChildrenByName(names, canvas);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
