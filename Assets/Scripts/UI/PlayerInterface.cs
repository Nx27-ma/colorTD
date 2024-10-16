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
    TMP_Text money;
    TMP_Text lives;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        string[] names = { "Money", "Lives" };
        displayFields = FindChildren.GetChildrenByName(names, canvas);
        money = displayFields[0].GetComponent<TMP_Text>();
        lives = displayFields[1].GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
