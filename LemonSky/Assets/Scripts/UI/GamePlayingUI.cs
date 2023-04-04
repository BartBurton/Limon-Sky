using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.Netcode;

public class GamePlayingUI : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        NetworkManager.Singleton.OnClientConnectedCallback += (clientId) =>
        {
            if (GameManager.Instance.IsGamePlaying())
                Show();
            else
                Hide();
        };
    }


    void Show()
    {
        gameObject.SetActive(true);
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }

    void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
            Show();
        else
            Hide();
    }
}
