using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int point = 1;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
        this.gameObject.SetActive(false);
    }
    
    protected virtual void GhostEat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
        this.gameObject.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PacMan"))
        {
            Eat();
        }
        
        else if (col.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            Debug.Log("fffffffff");
            GhostEat();
        }
    }
}
