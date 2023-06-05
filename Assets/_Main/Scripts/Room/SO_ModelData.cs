using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Model Data",menuName ="Scriptable Obj/Model Data")]
public class SO_ModelData : ScriptableObject
{
    public ModelType modelType;
    public ModelInfo[] modelInfos;
}

[System.Serializable]
public class ModelInfo
{
    public Mesh mesh;
    public Material material;
    public string modelName;
    public string modelIndex;
}

public enum ModelType { Floor,Wall,OnGround,OnWall,OnCelling}
