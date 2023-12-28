using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private string playerName;
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
