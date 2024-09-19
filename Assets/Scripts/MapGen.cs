using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;  

public class MapGen : MonoBehaviour
{
    
    GameObject cursorOverlay;
    List<Transform> path;
    public Spline spline;
    int i = 0;
    private GameObject pathRef;

    void Start()
    {

        pathRef = GameObject.Find("PathPoints");

        path = pathRef.GetComponentsInChildren<Transform>().ToList();
        Cursor.SetCursor(Texture2D.redTexture, new Vector2(1, 1), CursorMode.Auto);
        var splineContainer = pathRef.AddComponent<SplineContainer>();
        spline = new();
        createPath();
        splineContainer.AddSpline(spline);
        var splineExtrude = pathRef.AddComponent<SplineExtrude>();
        splineExtrude.Container = splineContainer;
        if (pathRef.TryGetComponent<MeshFilter>(out var meshFilter))
        {
            meshFilter.sharedMesh = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<MeshFilter>().mesh;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void createPath()
    {
        foreach (Transform pathPoint in path)
        {
            spline.Add(new BezierKnot(pathPoint.position)); 
        }
    }
    

    // void NewPoint()
    // {
    //     spline.Add(new BezierKnot(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3))));
    //     //spline[spline.Count].Position = Input.mousePosition;
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //
    //
    //         
    //
    //
    //
    //         Debug.Log(SplineUtility.EvaluatePosition(spline, 0.5f)); //EvalPos gives a location percentbased of the spline example 0.5f -> 50%  
    //         spline.EvaluateTangent(0.5f);   //EvalPos gives a rotation since previous point percentbased of the spline example 0.5f -> 50%  
    //         
    //         i += 1;
    //     }
    // }

}
