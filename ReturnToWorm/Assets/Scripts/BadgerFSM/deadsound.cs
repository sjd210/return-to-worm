using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadsound : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip dead_sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void play_sound(){

        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(dead_sound, 0.7F);
    }
}
