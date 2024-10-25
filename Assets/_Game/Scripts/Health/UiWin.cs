using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //SceneManager.LoadScene(winScene);
        SceneTransitionManager.Instance.LoadSceneWithLoadingScreen(winScene);

        StopCoroutine(time);
    }
}
