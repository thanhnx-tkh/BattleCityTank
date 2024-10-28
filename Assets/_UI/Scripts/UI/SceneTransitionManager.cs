using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    private string targetScene;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không xóa object khi load scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Hàm chuyển sang scene loading trước khi load scene đích
    public void LoadSceneWithLoadingScreen(string sceneToLoad)
    {
        targetScene = sceneToLoad;
        StartCoroutine(LoadSceneProcess());
        Time.timeScale = 1;
    }

    private IEnumerator LoadSceneProcess()
    {
        // Chuyển sang scene loading
        SceneManager.LoadScene("LoadingScreen");

        // Chờ một frame để scene loading được load hoàn toàn
        yield return null;

        // Bắt đầu load scene đích không đồng bộ
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);
        asyncLoad.allowSceneActivation = false;

        // Chờ đến khi load xong 90% (hoàn tất chuẩn bị)
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        // Chờ thêm một lúc cho hiệu ứng hoặc logic khác, nếu cần (tùy chọn)
        yield return new WaitForSeconds(1f);

        // Khi load xong thì kích hoạt chuyển sang scene đích
        asyncLoad.allowSceneActivation = true;
    }
}
