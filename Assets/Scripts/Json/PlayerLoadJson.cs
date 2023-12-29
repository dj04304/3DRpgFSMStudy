using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLoadJson : MonoBehaviour
{
    public Button jsonLoadButton;
    public Button gameStartButton;


    private void Start()
    {
        LoadJsonDataButtonEvent();
    }

    private void LoadJsonDataButtonEvent()
    {
        jsonLoadButton.onClick.AddListener(() => { LoadJsonData(); });
    }

    private void LoadJsonData()
    {
        PlayerData loadData = JsonDataManager.Instance.LoadFromJson<PlayerData>();

        gameStartButton.interactable = true;
    }
}
