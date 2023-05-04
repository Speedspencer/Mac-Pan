namespace Photon.Pun
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Photon.Pun;
    using UnityEngine;
    using UnityEngine.UI;

    public class ChatManager : MonoBehaviourPun, IPunObservable
    {
        public PlayerController plMove;
        public GameObject bubbleSpeechObject;
        public Text updatedText;

        private InputField ChatInputField;
        private bool disableSend;

        private void Awake()
        {
            ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                if (!disableSend && ChatInputField.isFocused)
                {
                    if (ChatInputField.text != "" && ChatInputField.text.Length > 0 && Input.GetKeyDown(KeyCode.T))
                    {
                        photonView.RPC("SendMessage", RpcTarget.AllBuffered, ChatInputField.text);
                        bubbleSpeechObject.SetActive(true);

                        ChatInputField.text = "";
                        disableSend = true;

                    }
                }
            }
        }

        [PunRPC]
        private new void SendMessage(string message)
        {
            updatedText.text = message;

            StartCoroutine("Remove");
        }

        IEnumerator Remove()
        {
            yield return new WaitForSeconds(4f);
            bubbleSpeechObject.SetActive(false);
            disableSend = false;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(bubbleSpeechObject.activeSelf);
            }
            else if (stream.IsReading)
            {
                bubbleSpeechObject.SetActive((bool) stream.ReceiveNext());

            }

        }
    }
}