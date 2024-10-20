using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum characterType
{
    Player,
    Enemy,
    Solider
}

public class Const : MonoBehaviour
{
    //Tag
    public const string borderTag = "Border";
    public const string wallTag = "Wall";
    public const string obstacleTag = "Obstacle";
    public const string enemyTag = "Enemy";
    public const string playerTag = "Player";

    //Anim
    public const string runParaname = "run";
    public const string shotParame = "shoot";
}
