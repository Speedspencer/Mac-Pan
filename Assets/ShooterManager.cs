using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ShooterManager : MonoBehaviour
{
    public Text pingText;

    private bool off = false;
    public GameObject disconnectUI;

    private void Update()
    {
        CheckInput();
        pingText.text = "PING : " + PhotonNetwork.GetPing();
    }

    private void CheckInput()
    {
        if (off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            off = false;
        }
        else if (!off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            off = true;
        }
      
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }
}
