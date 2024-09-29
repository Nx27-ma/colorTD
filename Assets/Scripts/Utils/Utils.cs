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

    /// <param name="parentObj">Give the parent of the children you want - Not needed to be direct children</param>
    /// <param name="giveGameObject">Whether you want it to return a GameObject or just the Components of the type</param>
    /// <returns>Either the Components of the Children or the GameObjects of the Children</returns>
    public static T[] getAllChildrenOfType<T>(Transform parentObj, bool giveGameObject) where T : Transform
    {
        if (giveGameObject)
        {
            return parentObj.transform.GetComponentsInChildren<T>()
                          .Select(i => i.transform.GetComponent<T>())
                          .ToArray();
        }
        else
        {
            return parentObj.transform.GetComponentsInChildren<T>();
        }
    }
}
