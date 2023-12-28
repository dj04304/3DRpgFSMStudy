using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSaveJson : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public Button createButton;

    private void Start()
    {
        CreateJsonButtonEvent();
    }

    private void CreateJsonButtonEvent()
    {
        createButton.onClick.AddListener(() => { SavePlayerNameToJson(); });
    }


    private void SavePlayerNameToJson()
    {
        string playerName = nameInput.text;

        PlayerData playerData = new PlayerData(playerName);

        Debug.Log(playerData.PlayerName);

        string name = JsonUtility.ToJson(playerData);


        JsonDataManager.Instance.SaveToJson(playerData, GetPlayerDataPath());

    }

    private string GetPlayerDataPath()
    {
        Debug.Log("저장 성공!");

        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");

        string fileName = "/07.JSON/layerData_" + timeStamp + ".json";

        return Application.dataPath + fileName;

    }

}
