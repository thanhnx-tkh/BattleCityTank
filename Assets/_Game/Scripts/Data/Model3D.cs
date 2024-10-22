using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Model3DData", menuName = "ScriptableObjects/Model3DData", order = 1)]
public class Model3D : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<Model3DData> itemDatas;

    public GameObject GetModel3D(int id)
    {
        foreach (var item in itemDatas)
        {
            if(item.id == id)
            {
                return item.gameObject3D;
            }
        }
        return null;
    }

    public Vector3 GetScaleModel3D(int id)
    {
        foreach (var item in itemDatas)
        {
            if (item.id == id)
            {
                return item.scale;
            }
        }
        return Vector3.zero;
    }
}

[System.Serializable]
public class Model3DData
{
    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int id;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public string name;

    [HorizontalGroup("Split", 75)]
    [HideLabel]
    [PreviewField(75)]
    [VerticalGroup("Split/Left")]
    public GameObject gameObject3D;

    [HideLabel]
    public Vector3 scale;
}

