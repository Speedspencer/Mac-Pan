using System;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : NetworkBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float speedMultiplier = 1f;
    
    [SerializeField] private Vector2 initialDirection = Vector2.right;
    [SerializeField] private LayerMask obstacleLayerMask;
    public Rigidbody2D Rb { get; private set; }
    public Vector2 Direction { get; private set; }
    public Vector2 NextDirection { get; private set; }
    public Vector3 StartingPosition { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position;
    }

    public override void OnNetworkSpawn()
    {
        ResetState();
    }
    
    public void ResetState()
    {
        speedMultiplier = 1f;
        Direction = initialDirection;
        NextDirection = Vector2.zero;
        Rb.isKinematic = false;
        transform.position = StartingPosition;
        enabled = true;
    }

    private void Update()
    {
        if(!IsOwner) return;
        if(NextDirection != Vector2.zero)
            SetDirection(NextDirection);
    }

    private void FixedUpdate()
    {
        if(!IsOwner) return;
        Vector2 position = Rb.position;
        Vector2 translation = Direction * (speed * speedMultiplier * Time.fixedDeltaTime);
        Rb.MovePosition(position + translation);
    }
    
    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (!Occupied(direction) || forced)
        {
            Direction = direction;
            NextDirection = Vector2.zero;
        }
        else
        {
            NextDirection = direction;
        }
        
    }
    
    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, obstacleLayerMask);
        return raycastHit.collider != null;
    }
}
