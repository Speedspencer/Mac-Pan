using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int point = 1;

    
    private bool isInsideTrigger = false;
    private float timeInsideTrigger = 0f;
    public float timeThreshold = 2f; // 2 seconds
    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
        this.gameObject.SetActive(false);
    }
    
    protected virtual void GhostEat()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PacMan"))
        {
            Debug.Log("Eat");
            Eat();
        }

        /*if (col.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            Debug.Log("ghost");
            GhostEat();
        }*/
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            isInsideTrigger = true;
            timeInsideTrigger += Time.deltaTime;

            if (timeInsideTrigger >= timeThreshold)
            {
                Debug.Log("Object has been inside the trigger for " + timeThreshold + " seconds!");
                GhostEat();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ghost"))
        {
            isInsideTrigger = false;
            timeInsideTrigger = 0f;
        }
    }
}
