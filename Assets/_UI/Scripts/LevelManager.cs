using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel;
    public int currentTankId;
    public bool isFrozen;
    public bool isResilient;
}
