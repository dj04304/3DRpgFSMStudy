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
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // �Ϲ� LoadScene�� �񵿱Ⱑ �ƴϱ� ������ �ε��ϴ� ���� ��� �ൿ�� �� �� ����
        op.allowSceneActivation = false; // ���� �񵿱�� �ҷ��� �� ���� �ε��� ������ �ڵ����� �ҷ��� ���� �̵��� �������� ����, false �� 90�ۼ�Ʈ���� ���� �Ѿ�� �ʰ� ���

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null; // �ݺ����� �� �� ���� ������� �Ѱ���

            if(op.progress < 0.9f) // 90�۱��� ���� ������ 90�ۺ��� ������ 
            {
                progressBar.fillAmount =op.progress;
            }
            else
            // ����ũ �ε����� ���ݾ� ä����
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                // �� ä��� true�� ��ȯ
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }

            }
        }

    }

}
