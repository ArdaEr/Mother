using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
   private AudioSource source;
   public static SoundManager instance{ get; private set; }

   private void Awake ()
   {
       instance = this;
       source = GetComponent<AudioSource>();
   }

   public void PlaySound(AudioClip _sound)
   {
       source.PlayOneShot(_sound);
   }
}
