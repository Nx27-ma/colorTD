using UnityEngine;
using UnityEngine.Rendering;


[RequireComponent(typeof(LineRenderer), typeof(MeshCollider))]

public class PathGeneration : MonoBehaviour
{
    Mesh Mesh;
    MeshCollider MeshCollider;
    LineRenderer LineRenderer;
    float DrawCooldown = 0.01f, DrawCooldownTimer;
    float PointDistance;
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
        if (LineRenderer.positionCount <= 0)
        {
            if (Input.GetMouseButton(0) && DrawCooldownTimer <= 0
            && Vector3.Distance(LineRenderer.GetPosition(LineRenderer.positionCount - 1), LineRenderer.GetPosition(LineRenderer.positionCount)) < PointDistance)
            {
                DrawCooldownTimer = DrawCooldown;
                Vector3 CusrorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                LineRenderer.positionCount++;
                CusrorWorldPos.z = 0;
                LineRenderer.SetPosition(LineRenderer.positionCount - 1, CusrorWorldPos);
                LineRenderer.BakeMesh(Mesh, false);
                MeshCollider.sharedMesh = Mesh;

            }
        }
        
    }
}





