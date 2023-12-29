using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSaveJson : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public Button createButton;

    public Button gameStartButton;
    public Image loginPanel;
    public Image completeText;

    private void Start()
    {
        StopAllCoroutines();

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

        //string name = JsonUtility.ToJson(playerData);

        JsonDataManager.Instance.SaveToJson(playerData);

        CompleteCreateData();

    }

    private void CompleteCreateData()
    {
        loginPanel.gameObject.SetActive(false);

        completeText.gameObject.SetActive(true);

        gameStartButton.interactable = true;

        Invoke("TextActiveTime", 2f);

        //StartCoroutine(TextActiveTime());

    }

    private void TextActiveTime()
    {
        completeText.gameObject.SetActive(false);
    
    }

    //IEnumerator TextActiveTime()
    //{
    //    yield return new WaitForSecondsRealtime(1.5f);

    //    completeText.gameObject.SetActive(false);
    //}

}
