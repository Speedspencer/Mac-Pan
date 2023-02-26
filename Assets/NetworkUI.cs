using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    

    private void Awake()
    {
        serverButton.onClick.AddListener(delegate
        {
            NetworkManager.Singleton.StartServer();
            NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });
        hostButton.onClick.AddListener(delegate
        {
            NetworkManager.Singleton.StartHost();
            NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });
        clientButton.onClick.AddListener(delegate
        {
            NetworkManager.Singleton.StartClient();
        });
    }
    
    
}
