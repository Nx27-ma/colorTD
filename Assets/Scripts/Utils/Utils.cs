using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class Utils
{
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

   public static GameObject[] getChildrenByName(string[] names, GameObject parentObj)
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


    public static GameObject[] getAllChildrenOfType(GameObject parentObj, Type type)
    {
        GameObject[] filtered = parentObj.transform.GetComponentsInChildren(type)
                  .Select(i => i.gameObject)
                  .ToArray();
        Debug.Log(filtered.Length);
        return filtered;
    }
}
