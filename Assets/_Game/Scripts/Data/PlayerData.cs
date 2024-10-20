using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public List<int> purchasedTankIds; 
    public List<int> tankLevels;  
    public int currentMoney; 
    public int currentScore;  
    public List<int> unlockedLevels; 
    public List<int> starLevels; 

    public PlayerData()
    {
        purchasedTankIds = new List<int>();
        tankLevels = new List<int>();
        unlockedLevels = new List<int>();
        starLevels = new List<int>();
        currentMoney = 0;
        currentScore = 0;
    }
}
