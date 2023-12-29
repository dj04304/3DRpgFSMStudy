using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    public PlayerSO playerSO;

    /// <summary>
    /// JsonData �̱���
    /// </summary>
    private static JsonDataManager _instance;
    public static JsonDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("JsonDataManager");
                _instance = singletonObject.AddComponent<JsonDataManager>();
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveToJson<T>(T Data)
    {
        Debug.Log(Data);
        //Debug.Log(filePath);

        string json = JsonUtility.ToJson(Data);

        string path = GetPlayerDataPath();

        Debug.Log("Json" + json);
        File.WriteAllText(path, json);
    }

    public T LoadFromJson<T>()
    {
       

        // Json ������ ����� ���丮 ���
        string directoryPath = Path.Combine(Application.dataPath + "/07.JSON");

       //Debug.Log(directoryPath);

        // ���丮�� �ִ� ��� Json ���� ��������
        string[] jsonFiles = Directory.GetFiles(directoryPath, "PlayerData_*.json");

        //Debug.Log(jsonFiles.Length);

        if(jsonFiles.Length > 0)
        {

            string filePath = jsonFiles[jsonFiles.Length - 1];
            string jsonData = File.ReadAllText(filePath);

            //Debug.Log(filePath);
            Debug.Log("������ �ҷ����� ����!");

            T loadedData = JsonUtility.FromJson<T>(jsonData);

            Debug.Log(loadedData);

            if (loadedData is PlayerData playerData)
            {
                playerSO.playerData.PlayerName = playerData.PlayerName;

                Debug.Log("playerName " + playerData.PlayerName);
            }

            return JsonUtility.FromJson<T>(jsonData);

        }
        else
        {
            return default(T);
        }

    }

    private string GetPlayerDataPath()
    {
        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");

        string fileName = "/07.JSON/PlayerData_" + timeStamp + ".json";

        return Path.Combine(Application.dataPath + fileName);

    }

}
