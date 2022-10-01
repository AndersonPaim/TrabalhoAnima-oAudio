using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMusic : MonoBehaviour
{

    int musicNow = 0;
   public  AudioSource audioSource;
   
    bool stop = false;
    public Slider musicBarra;
    public AudioClip[] musicGrop;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.pitch = 1;
        musicBarra.value = 1;
        ChageMusic();
        musicBarra.onValueChanged.AddListener(adicionarPich);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ChageMusic(int changeMUsic = 0)
    {
        musicNow += changeMUsic;
        if(musicNow >= musicGrop.Length)
        {
            musicNow = 0;
        }
        else if(musicNow<0)
        {
            musicNow = musicGrop.Length - 1;
        }
        if(audioSource.isPlaying && changeMUsic ==0)
        {
            return;
        }
        if(stop)
        {
            stop = false;
        }

        audioSource.clip = musicGrop[musicNow];

        audioSource.Play();
    }
    public void adicionarPich(float New_valor)
    {
        audioSource.pitch = musicBarra.value;
    }
    public void playStop()
    {
        audioSource.Stop();
        stop = true;
    }
}
