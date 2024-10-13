using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Utils
{
    public static class FindChildren
    {
        public static GameObject[] GetDirectChildren(GameObject parentObj, int amount = 0)
        {
            if (amount == 0) amount = parentObj.transform.childCount;
            GameObject[] children = new GameObject[amount];


            for (int i = 0; i < children.Length; i++)
            {
                children[i] = parentObj.transform.GetChild(i).gameObject;
            }

            return children;

            //if (amount == 0) amount = parentObj.transform.childCount;
            //List<Transform> tempList = parentObj.transform.GetComponentsInChildren<Transform>().Take(amount).ToList(); ;
            //tempList.RemoveAt(0);
            //return tempList.Select(i => i.gameObject).ToArray();
        }
        /// <summary>
        /// Returns all the children with the specified names 
        /// Excludes the parent
        /// </summary>
        /// <param name="names"></param>
        /// <param name="parentObj"></param>
        /// <returns>GameObject[]</returns>
        public static GameObject[] GetChildrenByName(string[] names, GameObject parentObj)
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

            //return parentObj.GetComponentsInChildren<Transform>().Where(i => names.ToList().Contains(i.name)).Select(i => i.gameObject).ToArray();
        }

        /// <param name="parentObj">Give the parent of the children you want - Not needed to be direct children</param>
        /// <param name="giveGameObject">Whether you want it to return a GameObject or just the Components of the type</param>
        /// <returns>Either the Components of the Children or the GameObjects of the Children</returns>
        public static T[] GetAllChildrenOfType<T>(GameObject parentObj, bool giveGameObject = false) where T : Component
        {
            if (giveGameObject)
            {
                return parentObj.gameObject.GetComponentsInChildren<T>()
                              .Select(i => i.gameObject.GetComponent<T>())
                              .ToArray();
            }
            else
            {
                return parentObj.gameObject.GetComponentsInChildren<T>();
            }
        }
    }
}