using System.Collections;
using System.Collections.Generic;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;  

public class MapGen : MonoBehaviour
{
    
    GameObject cursorOverlay;
    List<GameObject> path;
    Spline spline;
    int i = 0;

    void Start()
    {

        Cursor.SetCursor(Texture2D.redTexture, new Vector2(1,1), CursorMode.Auto);
        spline = new();     
        path = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        PlacePoint();
    }

    void PlacePoint()
    {
        if (Input.GetMouseButtonDown(0))
        {


            spline.Add(new BezierKnot(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3))));



            Debug.Log(SplineUtility.EvaluatePosition(spline, 0.5f)); //EvalPos gives a location percentbased of the spline example 0.5f -> 50%  
            spline.EvaluateTangent(0.5f);   //EvalPos gives a rotation since previous point percentbased of the spline example 0.5f -> 50%  
            
            i += 1;
        }
    }

}
