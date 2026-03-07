using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    // Hàm này chỉ nhận tên màn chơi và đợi một chút rồi mới load
    public void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(WaitToLoad(sceneName));
    }

    IEnumerator WaitToLoad(string sceneName)
    {
        // Đợi 0.25 giây để tiếng click kịp phát ra [cite: 2026-02-28]
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(sceneName);
    }
}