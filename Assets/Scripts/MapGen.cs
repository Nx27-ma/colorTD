using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    
    GameObject cursorOverlay;
    List<GameObject> path;


    void Start()
    {
        Cursor.SetCursor(Texture2D.redTexture, new Vector2(1,1), CursorMode.Auto);
        path = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int i = 0;
            GameObject drawSphere = GameObject.CreatePrimitive(PrimitiveType.Plane);
            drawSphere.transform.position = Camera.main.ScreenToWorldPoint(cursorOverlay.transform.position);
            
        }
    }
}
