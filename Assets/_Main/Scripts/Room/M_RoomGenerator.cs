using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RoomGenerator : MonoBehaviour
{
    public SO_ModelData md_Wall;
    public SO_ModelData md_Floor;
    public Transform environment;

    public Vector2 roomSize;

    void Start()
    {
        //floorSize = mesh_Floor.bounds.size;
        RoomGeneration();
    }

    void Update()
    {
        
    }

    public void RoomGeneration()
    {
        float roomWidth = md_Floor.modelInfos[0].mesh.bounds.size.x;
        float roomLength = md_Floor.modelInfos[0].mesh.bounds.size.z;

        for (int i = 1; i < roomSize.x; i++)
        {
            for (int j = 1; j < roomSize.y; j++)
            {
                GameObject newFloor = new GameObject("Floor" + " " + i + " " + j);
                newFloor.AddComponent<MeshFilter>().mesh = md_Floor.modelInfos[0].mesh;
                newFloor.AddComponent<MeshRenderer>().material = md_Floor.modelInfos[0].material;
                newFloor.transform.position = new Vector3(roomWidth * i, 0, roomLength * j);
            }
        }

        for (int i = 0; i < roomSize.x; i++)
        {
            for (int j = 1; j < roomSize.y; j++)
            {
                GameObject newWall = new GameObject("Wall" + " " + i + " " + j);
                newWall.AddComponent<MeshFilter>().mesh = md_Wall.modelInfos[0].mesh;
                newWall.AddComponent<MeshRenderer>().material = md_Wall.modelInfos[0].material;
                newWall.transform.position = new Vector3(roomWidth * i, 0, roomLength * j);
            }
        }
    }
}
