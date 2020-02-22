using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour
{
    public bool play;
    public AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        play = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && !play)
        {
            play = true;
            myAudioSource.Play();
        }
        if(Input.GetButtonDown("Weapon Attack") && play)
        {
            play = false;
            myAudioSource.Stop();
        }
    }
}
