using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int point = 10;

    protected virtual void Eat()
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
    }
}
