
using System;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Movement Movement { get; private set; }
    
    private NetworkObject networkObject;

    private void Awake()
    {
        Movement = GetComponent<Movement>();
        networkObject = GetComponent<NetworkObject>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(Movement.Direction.y, Movement.Direction.x) * Mathf.Rad2Deg;
        if (IsLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                InputServerRpc(angle, Vector2.up);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                InputServerRpc(angle, Vector2.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                InputServerRpc(angle, Vector2.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                InputServerRpc(angle, Vector2.right);
        }
        else if (IsServer)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                Movement.SetDirection(Vector2.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                Movement.SetDirection(Vector2.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                Movement.SetDirection(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                Movement.SetDirection(Vector2.right);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        
        
        
    }

    [ServerRpc]
    public void InputServerRpc(float angle, Vector2 direction)
    {
        Movement.SetDirection(direction);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
}
