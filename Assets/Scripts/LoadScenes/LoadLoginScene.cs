using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLoginScene : MonoBehaviour
{
    private Button startButton;

    private void Awake()
    {
        startButton = GetComponent<Button>();
    }

    void Start()
    {
        LoginLoadSceneButtonEvent();
    }

    private void LoginLoadSceneButtonEvent()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene("LoginScene"); }) ;
    }

}
