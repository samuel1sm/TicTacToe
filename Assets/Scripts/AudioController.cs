using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void PlayButtonSound()
    {
        AudioManager.Instance.PlaySound(Sound.ButtonClicked);
    }
    
    public void PlayScrollSound()
    {
        AudioManager.Instance.PlaySound(Sound.ScrollSound);
    }
    
    public void PlayWinItemSound()
    {
        AudioManager.Instance.PlaySound(Sound.NewItem);
    }

    public void PlayIconPlaced()
    {
        AudioManager.Instance.PlaySound(Sound.SetIcon);
    }
    
}
