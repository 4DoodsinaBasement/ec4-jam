using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundEffectPlayer;

    // public AudioClip 
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
