using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWin : MonoBehaviour
{
    [SerializeField] private string winScene;
    public int timeCount;
    private Coroutine time;
    private void Start()
    {
        time = StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        while (timeCount > 0)
        {
            yield return new WaitForSeconds(1);
            timeCount--;
        }
        ChangeScene.Ins.QuitToMainMenu(winScene);
        StopCoroutine(time);
    }
}
