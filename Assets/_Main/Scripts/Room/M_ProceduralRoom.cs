using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ProceduralRoom : MonoBehaviour
{
    public Vector2 roomSize;
    private Vector2 wallSize;
    List<Matrix4x4> wallMatricesN;
    public Mesh m_Wall_1;
    public Mesh m_Wall_2;
    public Mesh m_Wall_3;
    public Mesh m_Pillar;
    public Mesh m_Floor;

    public Material mat_Wall;

    void Start()
    {
        //wallSize = m_Wall_1.
    }

    void Update()
    {
        CreateWalls();
        RenderWalls();
    }

    void CreateWalls()
    {
        wallMatricesN = new List<Matrix4x4>();

        int wallCount = Mathf.Max(1, (int)(roomSize.x / wallSize.x));
        float scale = (roomSize.x / wallCount) / wallSize.x;

        for (int i = 0; i < wallCount; i++)
        {
            Vector3 t = transform.position + new Vector3(-roomSize.x / 2 + wallSize.x * scale / 2 + i * scale * wallSize.x, 0, -roomSize.y / 2);
            Quaternion r = transform.rotation;
            Vector3 s = new Vector3(scale, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatricesN.Add(mat);
        }
    }

    void RenderWalls()
    {
        if (wallMatricesN!=null)
        {
            Graphics.DrawMeshInstanced(m_Wall_1, 0, mat_Wall, wallMatricesN.ToArray(), wallMatricesN.Count);
        }
    }
}
