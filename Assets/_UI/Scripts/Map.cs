using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : UICanvas
{
    void Start()
    {
        
    }
    private void OnEnable() {
        transform.SetAsFirstSibling();
    }

}
