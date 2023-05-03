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
   private PhotonView view;

   public Text playerText;

   public SpriteRenderer sr;
   
   private void Awake()
   {
   }

   private void Start()
   {
      view = GetComponent<PhotonView>();
      /*
      playerText.text = PhotonNetwork.NickName;
      */

      if (view.IsMine)
      {
         PlayerCamera.SetActive(true);
         playerText.text = PhotonNetwork.NickName;
      }
      else
      {
         playerText.text = view.Owner.NickName;
         playerText.color = Color.red;
      }
   }

   private void Update()
   {
      if (view.IsMine)
      {
         CheckInput();
      }
      
      /*if (view.IsMine)
      {
         Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

         transform.position += input.normalized * speed * Time.deltaTime;
      }*/
    
   }

   private void CheckInput()
   {
      var move = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
      transform.position += move * speed * Time.deltaTime;

      if (Input.GetKeyDown(KeyCode.A))
      {
         sr.flipX = false;
      } 
      if (Input.GetKeyDown(KeyCode.D))
      {
         sr.flipX = true;
      }
   }
}
