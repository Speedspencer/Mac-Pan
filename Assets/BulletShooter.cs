using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletShooter : MonoBehaviourPun
{
    public bool moveDir = false;
    public float moveSpeed;
    public float destroyTime;

    public PhotonView photonView;

    public float bulletDamage;

    private void Awake()
    {
        StartCoroutine("DestroyByTime");
    }
    

    IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void ChangeDir_Left()
    {
        moveDir = true;
    }
 
    [PunRPC]
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (!moveDir)
        {
          
            transform.Translate(Vector2.right * moveSpeed* Time.deltaTime);
        }
        else
        {
          
            transform.Translate(Vector2.left * moveSpeed* Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        PhotonView target = col.gameObject.GetComponent<PhotonView>();

        if (target != null && (!target.IsMine || target.IsRoomView))
        {
            if (target.tag == "Player")
            {
                target.RPC("ReduceHealth", RpcTarget.AllBuffered , bulletDamage );
            }
            this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.AllBuffered);
        }
    }
}
