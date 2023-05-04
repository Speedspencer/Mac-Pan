using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

   public Rigidbody2D rb;
   public GameObject PlayerCamera;
   public float speed;
   public PhotonView view;

   public Text playerText;

   public SpriteRenderer sr;

   public GameObject bullet;
   public Transform firePos;
   
   private void Awake()
   {
      
      if (view.IsMine)
      {
         PlayerCamera.SetActive(true);
         playerText.text = PhotonNetwork.NickName;
      }
      else
      {
         PlayerCamera.SetActive(false);
         playerText.text = view.Owner.NickName;
         playerText.color = Color.green;
         
      }
   }

   private void Update()
   {
      if (view.IsMine)
      {
         CheckInput();
      }
      
   }

   private void CheckInput()
   {
      var move = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
      transform.position += move * speed * Time.deltaTime;

      if (Input.GetKeyDown(KeyCode.Space))
      {
         Shoot();
      }

      if (Input.GetKeyDown(KeyCode.A))
      {
         view.RPC("FlipFalse", RpcTarget.AllBuffered);
         
      } 
      if (Input.GetKeyDown(KeyCode.D))
      {
         view.RPC("FlipTrue", RpcTarget.AllBuffered);
      }
      
    
   }

   private void Shoot()
   {
      
      if (sr.flipX == false)
      {
    
         GameObject obj = PhotonNetwork.Instantiate(bullet.name,
            new Vector2(firePos.transform.position.x, firePos.transform.position.y), Quaternion.identity, 0);
      }
      
      if (sr.flipX == true)
      {
         GameObject obj = PhotonNetwork.Instantiate(bullet.name,
            new Vector2(firePos.transform.position.x, firePos.transform.position.y), Quaternion.identity, 0);
         
         obj.GetComponent<PhotonView>().RPC("ChangeDir_Left", RpcTarget.AllBuffered);
      }
      
      
   }

   [PunRPC]
   private void FlipTrue()
   {
      sr.flipX = true;

   }
   
   [PunRPC]
   private void FlipFalse()
   {
      sr.flipX = false;

   }
   
}
