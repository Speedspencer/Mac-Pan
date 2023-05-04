using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
    
public class Health : MonoBehaviour
{
    public Image fillImage;
    private PhotonView photonView;
    
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    
    [PunRPC]
    public void ReduceHealth(float amount)
    {
        ModifyHealth(amount);
    }
    
    public void ModifyHealth(float amount)
    {
        if (photonView.IsMine)
        {
            fillImage.fillAmount -= amount;
        }
        else
        {
            fillImage.fillAmount -= amount;

        }
    }
}
