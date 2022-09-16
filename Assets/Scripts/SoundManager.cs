using UnityEngine.Audio;
using UnityEngine;
using System; 

public class SoundManager : MonoBehaviour
{
    public static Canciones[] cancion; 
    void Awake()
    {
        foreach(Canciones s in cancion){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 

        }
    
        
    }
    public void Start(){
        Play("Menú");
    }
    public void Play(string name){
        Canciones s = Array.Find(cancion,sound => sound.name == name);
        s.source.Play();
    }
    
}
