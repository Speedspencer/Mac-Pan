using System;
using System.Collections;
using System.Collections.Generic;
using ParrelSync.NonCore;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 position = col.transform.position;
        position.x = connection.position.x;
        position.y = connection.position.y;
        col.transform.position = position;
    }
}
