using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private AudioSource buttonsource;
    [SerializeField] private AudioClip hoversound;
    [SerializeField] private AudioClip clicksound;

    public void PlayHover()
    {
        buttonsource.PlayOneShot(hoversound);
    }
    public void PlayClick()
    {
        buttonsource.PlayOneShot(clicksound);
    }
}
