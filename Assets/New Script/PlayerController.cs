using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviour
{

   public float speed;
   private PhotonView view;

   private void Start()
   {
      view = GetComponent<PhotonView>();
   }

   private void Update()
   {
      if (view.IsMine)
      {
         Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

         transform.position += input.normalized * speed * Time.deltaTime;
      }
    
   }
}
