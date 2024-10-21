using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLose : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject buttonQuit;
    [SerializeField] private string lostScene;
    public int timeCount;
    public int timeEnableLose;
    private Coroutine time;
    private Coroutine sceneLost;
    private void Start()
    {
       time = StartCoroutine(Wait());
       sceneLost = StartCoroutine(ShowLose());
    }
    private IEnumerator Wait()
    {
        while (timeCount > 0)
        {
            text.text = timeCount.ToString();
            yield return new WaitForSeconds(1);
            timeCount--;
        }
        buttonQuit.SetActive(true);
        StopCoroutine(time);
    }
    private IEnumerator ShowLose()
    {
        while (timeEnableLose > 0)
        {
            yield return new WaitForSeconds(1);
            timeEnableLose--;
        }
        ChangeScene.Ins.QuitToMainMenu(lostScene);
        StopCoroutine(sceneLost);
    }
}
