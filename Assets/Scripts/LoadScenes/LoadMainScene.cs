using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMainScene : MonoBehaviour
{
    private Button gameStartButton;

    private void Awake()
    {
        gameStartButton = GetComponent<Button>();
    }

    void Start()
    {
        LoginLoadSceneButtonEvent();
    }

    private void LoginLoadSceneButtonEvent()
    {
        gameStartButton.onClick.AddListener(() => { LoadingSceneController.LoadScene("MainScene"); });
    }
}
