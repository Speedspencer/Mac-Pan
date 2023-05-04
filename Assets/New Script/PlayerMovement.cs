using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    [SerializeField] private Vector2 initialDirection = Vector2.right;
    
    public Rigidbody2D Rb { get; private set; }
    
    public Vector2 Direction { get; private set; }
    
    public Vector2 NextDirection { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        
        if (photonView.IsMine)
        {
            Direction = initialDirection;
            NextDirection = Vector2.zero;
        }
        else
        {
            
        }

    }
    
    private void Update()
    {
        if(NextDirection != Vector2.zero)
            SetDirection(NextDirection);
    }

    [PunRPC]
    public void SetDirection(Vector2 direction, bool forced = false)
    {
        
    }

}
