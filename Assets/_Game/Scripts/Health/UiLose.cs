using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiLose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
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
        //SceneManager.LoadScene(lostScene);
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(lostScene);

        StopCoroutine(sceneLost);
    }
}
