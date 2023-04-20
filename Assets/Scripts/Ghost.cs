using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = 50;
    public Movement Movement { get; private set; }
    
    public GhostFrightened frightend { get; private set; }

    public Transform target;

    private void Awake()
    {
        this.frightend = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.frightend.Disable();
        this.gameObject.SetActive(true);
        //this.Movement.ResetState();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PacMan"))
        {
            if (this.frightend.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
