using Unity.Netcode.Components;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    private void OnTriggerEnter2D(Collider2D col)
    {
        NetworkTransform networkTransform = col.GetComponent<NetworkTransform>();
        var colTransform = col.transform;
        var connectionPosition = connection.position;
        networkTransform.Teleport(new Vector3(connectionPosition.x, connectionPosition.y, colTransform.position.z), colTransform.rotation, colTransform.localScale);
    }
}
