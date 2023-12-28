using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    /// <summary>
    /// JsonData ΩÃ±€≈Ê
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

    public void SaveToJson<T>(T Data, string filePath)
    {
        Debug.Log(Data);
        //Debug.Log(filePath);

        string json = JsonUtility.ToJson(Data);

        string path = Path.Combine(filePath);

        Debug.Log("Json" + json);
        File.WriteAllText(path, json);
    }

    public T LoadFromJson<T>(string filePath)
    {
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            return default(T);
        }

    }

}
