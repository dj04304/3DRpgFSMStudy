using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Player player { get; private set; }
    public TextMeshProUGUI playerName;

    private void Start()
    {
        player = GetComponent<Player>();
        PlayerNameText();
    }

    private void PlayerNameText()
    {
        //Debug.Log(player.Data.GetPlayerName());
        playerName.text = player.Data.GetPlayerName();
    }

}
