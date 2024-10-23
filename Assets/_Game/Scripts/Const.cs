using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    BasicTank,
    BasicFastTank,
    PowerTank,
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
    public const string bulletTag = "Bullet";
    public const string bulletPlayerTag = "BulletPlayer";
    public const string baseTag = "Base";
    public const string spamWaveTag = "SpamWave";
    public const string spawnPlayerTag = "SpawnPlayer";

    //Anim
    public const string runParaname = "run";
    public const string shotParame = "shoot";

    //NameUi
    public const string uiLose = "Ui_Loser";

}
