using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
   
    public AudioClip hit;
    public AudioClip knockout;
    public AudioClip shoot;
    public AudioClip recover;
    
    public void OnHitPlay()
    {
        AudioSource.PlayClipAtPoint(hit, transform.position);

    }
    
    public void OnKnockoutPlay()
    {
        AudioSource.PlayClipAtPoint(knockout, transform.position);

    }
    
    public void OnShootPlay()
    {
        AudioSource.PlayClipAtPoint(shoot, transform.position);
    }
    
    public void OnRecoverPlay()
    {
        AudioSource.PlayClipAtPoint(recover, transform.position);
    }
}
