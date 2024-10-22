using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObserver : MonoBehaviour
{
    private void Start() {
        Observer.AddObserver("UpdateUI",UpdateUI);
    }
    public void UpdateUI(object[] datas){
        Debug.Log("UpdateUI");
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            Observer.Notify("UpdateUI");
        }
    }
    public void OnDestroy(){
        Observer.RemoveObserver("UpdateUI",UpdateUI);
    }
}
