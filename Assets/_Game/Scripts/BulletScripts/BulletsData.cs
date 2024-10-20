using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/Bullet", order = 1)]
public class BulletsData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<BulletData> bulletData;
}
[System.Serializable]
public class BulletData
{
    [HorizontalGroup("Split", 75)]
    [HideLabel]
    [PreviewField(75)]
    [VerticalGroup("Split/Left")]
    public Sprite sprite;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int id;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject baseBullet;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    [Range(0, 300)]
    [GUIColor(0.5f, 0.5f, 1f)]
    public float speed;
}