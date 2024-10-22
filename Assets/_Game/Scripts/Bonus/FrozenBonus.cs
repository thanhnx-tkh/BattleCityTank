using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBonus : Singleton<FrozenBonus>
{
    [field: SerializeField] public bool isFrozen {  get; set; }
    public void UseFrozenBonus()
    {
        isFrozen = true;
    }
}
