using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private string playerName; // 직렬화 역직렬화를 해주기 위해  [SerializeField] 를 넣어야 한다.
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public PlayerData(string playerName)
    {
        this.playerName = playerName;
    }

}
