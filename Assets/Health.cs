using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Health : MonoBehaviourPun
{
    public Image fillImage;
    
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
