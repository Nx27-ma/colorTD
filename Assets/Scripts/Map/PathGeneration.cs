using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Utils;

[RequireComponent(typeof(LineRenderer), typeof(MeshCollider))]

public class PathGeneration : MonoBehaviour
{
    Mesh Mesh;
    MeshCollider MeshCollider;
    LineRenderer LineRenderer;
    float DrawCooldown = 0.01f, DrawCooldownTimer;
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        LineRenderer.positionCount = 0;
        MeshCollider = GetComponent<MeshCollider>();
        Mesh = new();
    }

    void Update()
    {
        DrawCooldownTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && DrawCooldownTimer <= 0)
        {
            DrawCooldownTimer = DrawCooldown;
            LineRenderer.positionCount++;
            Vector3 CusrorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            CusrorWorldPos.z = 0;
            LineRenderer.SetPosition(LineRenderer.positionCount -1, CusrorWorldPos);

            LineRenderer.BakeMesh(Mesh, true);
            MeshCollider.sharedMesh = Mesh;
        }
    }
}

   



