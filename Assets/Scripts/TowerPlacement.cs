using System.Collections;
using UnityEngine;
public class TowerPlace : MonoBehaviour
{
    GameObject Default;
    UIClickHandler uiClickHandler;
    private Vector3 cursorPos;
    GameObject pathPointObj;
    GameObject[] pathPoints;


    bool path = false, otherTower = false, reinstantiate = true;
    private bool firstCatch = true;

    void Start()
    {
        Default = GameObject.Find("DEFAULT");
        uiClickHandler = Default.GetComponent<UIClickHandler>();        //for interaction with the ui
        pathPointObj = GameObject.Find("PathPoints");
        pathPoints = Utils.getDirectChildren(pathPointObj);
        LineDraw line = new(new Vector2(1, 1), new Vector2(3, 4), new Vector2(4, 5));

    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        if (uiClickHandler.SelectedGameObject != null && firstCatch)
        {
            StartCoroutine(inputTowerPlacement());
            firstCatch = false;
        }
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < pathPoints.Length; i++)
        {
            Gizmos.DrawSphere(pathPoints[i].transform.position, 0.5f);
        }
    }
    bool checkValidPlacement()
    {
        path = false;
        otherTower = false;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (Vector3.Distance(cursorPos, pathPoints[i].transform.position) > 0.5f)
            {
                path = true;
            }
        }






        return true;
    }

    IEnumerator inputTowerPlacement()
    {
        uiClickHandler.SelectedGameObject.transform.position = cursorPos;
        yield return new WaitForFixedUpdate();

        if (Input.GetMouseButtonDown(0))
        {

        }
        else { StartCoroutine(inputTowerPlacement()); }
    }




}

