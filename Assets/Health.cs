using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Health : MonoBehaviourPun
{
    public float healthAmount;
    public Image fillImage;

    public PlayerController plMove;

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public SpriteRenderer sr;
    public GameObject playerCanvas;


    private void Awake()
    {
        if (photonView.IsMine)
        {
            ShooterManager.instance.localPlayer = this.gameObject;
        }
    }

    [PunRPC]
    public void ReduceHealth(float amount)
    {
        ModifyHealth(amount);
    }

    private void CheckHealth()
    {
        fillImage.fillAmount = healthAmount / 10f;
        if (photonView.IsMine && healthAmount <= 0)
        {
            ShooterManager.instance.EnableRespawn();
            plMove.disableInput = true;
            this.GetComponent<PhotonView>().RPC("Dead", RpcTarget.AllBuffered);
        }
    }

    public void EnableInput()
    {
        plMove.disableInput = false;
    }

    [PunRPC]
    private void Dead()
    {
        rb.gravityScale = 0;
        bc.enabled = false;
        sr.enabled = false;
        playerCanvas.SetActive(false);
    }
    
    [PunRPC]
    private void Respawn()
    {
        rb.gravityScale = 0;
        bc.enabled = true;
        sr.enabled = true;
        playerCanvas.SetActive(true);
        fillImage.fillAmount = 1f;
        healthAmount = 10f;
    }
    
    public void ModifyHealth(float amount)
    {
        if (photonView.IsMine)
        {
            healthAmount -= amount;
            fillImage.fillAmount -= amount;
        }
        else
        {
            healthAmount -= amount;
            fillImage.fillAmount -= amount;

        }
        
        CheckHealth();
    }
}
