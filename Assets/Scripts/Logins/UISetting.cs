using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    public Button newDataButton;
    public Button loadDataButton;
    public Button closedButton;
    public Image LoginPanel;


    private void Start()
    {
        CreateButtonClickEvent();
        ClosedButtonClickEvent();
    }

    private void CreateButtonClickEvent()
    {
        if (newDataButton != null)
        {
            newDataButton.onClick.AddListener(() => {if(LoginPanel != null ) LoginPanel.gameObject.SetActive(true);  });
        }
    }

    private void ClosedButtonClickEvent()
    {
        if(closedButton != null)
        {
            closedButton.onClick.AddListener(() => { if (LoginPanel != null) LoginPanel.gameObject.SetActive(false); });
        }
    }


}
