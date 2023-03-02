using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : NetworkBehaviour
{
    [SerializeField] private Button pacman;
    [SerializeField] private Button ghost;
    [SerializeField] private Transform pacmanPrefab;
    [SerializeField] private Transform ghostPrefab;

    private void Awake()
    {
        pacman.onClick.AddListener(delegate
        {
            if(!IsOwner) return;
            gameObject.SetActive(false);
        });
        ghost.onClick.AddListener(delegate
        {
            if(!IsOwner) return;
            gameObject.SetActive(false);
        });
    }
    
    //Spawn the character on the server when press the button
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            if (IsOwner)
            {
                if (pacmanPrefab != null)
                {
                    Transform pacman = Instantiate(pacmanPrefab, transform.position, Quaternion.identity);
                    NetworkObject pacmanNetworkObject = pacman.GetComponent<NetworkObject>();
                    pacmanNetworkObject.Spawn();
                }
            }
            else
            {
                if (ghostPrefab != null)
                {
                    Transform ghost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
                    NetworkObject ghostNetworkObject = ghost.GetComponent<NetworkObject>();
                    ghostNetworkObject.Spawn();
                }
            }
        }
    }
    
    
}
    
