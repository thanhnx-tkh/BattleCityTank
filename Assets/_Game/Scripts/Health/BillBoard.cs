using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform camMain;
    private void Start()
    {
        camMain = Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camMain.forward);
    }
}
