using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShooterManager : MonoBehaviour
{
    public SoundController sound;

    public static ShooterManager instance;
    public Text pingText;

    private bool off = false;
    public GameObject disconnectUI;

    [HideInInspector]public GameObject localPlayer;
    public Text respawnTimer;
    public GameObject respawnMenu;
    private float timerAmount = 5f;
    private bool runSpawnTimer = false;
    
    public Transform[] spawnPoints;

    private void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        CheckInput();
        pingText.text = "PING : " + PhotonNetwork.GetPing();

        if (runSpawnTimer)
        {
            StartRespawn();
        }
    }

    public void EnableRespawn()
    {
        timerAmount = 5f;
        runSpawnTimer = true;
        respawnMenu.SetActive(true);
    }

    private void StartRespawn()
    {
        timerAmount -= Time.deltaTime;
        respawnTimer.text = "Respawning in " + timerAmount.ToString("F0");

        if (timerAmount <= 0)
        {
            localPlayer.GetComponent<PhotonView>().RPC("Respawn", RpcTarget.AllBuffered);
            localPlayer.GetComponent<Health>().EnableInput();
            RespawnLocation();
            respawnMenu.SetActive(false);
            runSpawnTimer = false;
        }
    }

    public void RespawnLocation()
    {
        int randomValue = Random.Range(0,spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomValue];
        localPlayer.transform.localPosition = new Vector2(spawnPoint.position.x,spawnPoint.position.y);
        sound.OnRecoverPlay();
        
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
        //PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.LoadLevel(0);
    }
}
