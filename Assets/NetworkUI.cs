using System.Text.RegularExpressions;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    
    [SerializeField] private TMP_InputField ipInput;
    [SerializeField] private UnityTransport transport;


    public void Awake()
    {
        serverButton.onClick.AddListener(delegate
        {
            if (NetworkCheck()) return;
            NetworkManager.Singleton.StartServer();
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });
        hostButton.onClick.AddListener(delegate
        {
            if (NetworkCheck()) return;
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });
        clientButton.onClick.AddListener(delegate
        {
            if (NetworkCheck()) return;
            NetworkManager.Singleton.StartClient();
        });
    }

    private bool NetworkCheck()
    {
        // if (transport.ConnectionData.Address == "127.0.0.1")
        //     if (!CheckIP())
        //         return true;
        if (NetworkManager.Singleton.IsListening) return true;
        return false;
    }

    private bool CheckIP()
    {
        if (Regex.IsMatch(ipInput.text,
                @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$"))
        {
            transport.ConnectionData.Address = ipInput.text;
            return true;
        }
        Debug.LogError("Invalid IP");
        return false;
    }
    
    
}
