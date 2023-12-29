using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // 일반 LoadScene은 비동기가 아니기 때문에 로드하는 동안 어떠한 행동도 할 수 없음
        op.allowSceneActivation = false; // 씬을 비동기로 불러올 때 씬의 로딩이 끝나면 자동으로 불러온 씬을 이동할 것인지를 설정, false 면 90퍼센트에서 씬이 넘어가지 않고 대기

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null; // 반복문이 돌 때 마다 제어권을 넘겨줌

            if(op.progress < 0.9f) // 90퍼까지 차기 때문에 90퍼보다 낮으면 
            {
                progressBar.fillAmount =op.progress;
            }
            else
            // 페이크 로딩으로 조금씩 채워줌
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                // 다 채우면 true로 변환
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }

            }
        }

    }

}
