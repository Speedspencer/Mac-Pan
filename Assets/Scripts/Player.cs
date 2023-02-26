
using System;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Movement Movement { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if(!IsOwner) return;
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Movement.SetDirection(Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            Movement.SetDirection(Vector2.down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            Movement.SetDirection(Vector2.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            Movement.SetDirection(Vector2.right);
        
        float angle = Mathf.Atan2(Movement.Direction.y, Movement.Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
