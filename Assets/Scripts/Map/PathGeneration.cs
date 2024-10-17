using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Utils;

//NOT USED

//public class PathGeneration : MonoBehaviour

//{

//    GameObject[] pathPoints;
//    float width = 0.5f;


//    void Start()
//    {
//        GameObject path = GameObject.Find("PathPoints");
//        meshObj = new GameObject();
//        pathPoints = FindChildren.GetDirectChildren(path);

//        pointA = pathPoints[0].transform.position;
//        pointB = pathPoints[1].transform.position;
//        meshFilter = meshObj.AddComponent<MeshFilter>();
//        MeshRenderer = meshObj.AddComponent<MeshRenderer>();

//        GenerateMesh();

//    }

//    void GenerateMesh()
//    {

//        Vector3 direction = (pointB - pointA).normalized;
//        float length = Vector3.Distance(pointA, pointB);


//        Vector3 right = Vector3.Cross(direction, Vector3.up).normalized * width / 2;

//        // Vertices of the quad (clockwise)
//        Vector3[] vertices = new Vector3[4];
//        vertices[0] = pointA + right;
//        vertices[1] = pointA - right;
//        vertices[2] = pointB + right;
//        vertices[3] = pointB - right;

//        // Create a new mesh
//        mesh = new Mesh();
//        mesh.vertices = vertices;

//        // Define the triangles (two triangles for the quad)
//        int[] triangles = new int[6];
//        triangles[0] = 0;
//        triangles[1] = 2;
//        triangles[2] = 1;
//        triangles[3] = 2;
//        triangles[4] = 3;
//        triangles[5] = 1;

//        // Assign the triangles to the mesh
//        mesh.triangles = triangles;

//        // Calculate normals for lighting
//        mesh.RecalculateNormals();

//        // Assign the mesh to the MeshFilter
//        meshFilter.mesh = mesh;
//       meshObj.transform.localEulerAngles = new Vector3(-90, 0, 0);

//    }

   
//}


