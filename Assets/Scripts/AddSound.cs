using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource voiceLine;
    public AudioClip[] vl;
    void Start()
    {
        voiceLine = gameObject.AddComponent<AudioSource>();
        
    
    }

    // Update is called once per frame

}
