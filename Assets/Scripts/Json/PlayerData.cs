using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private string playerName; // ����ȭ ������ȭ�� ���ֱ� ����  [SerializeField] �� �־�� �Ѵ�.
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
