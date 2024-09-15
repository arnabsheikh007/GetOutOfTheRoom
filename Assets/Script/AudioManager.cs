using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.loop = sound.loop;
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
        Debug.Log("Hello");
        playSound("Theme");
    }

    public void playSound(string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
                sound.source.Play();
                Debug.Log(sound.name + "Played");
            }
        }
    }

}
